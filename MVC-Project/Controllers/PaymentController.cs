using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Models.Cart;
using MVC_Project.Models.Order;
using MVC_Project.Models.Paypal;
using PayPal.Api;

namespace MVC_Project.Controllers
{
    public class PaymentController : Controller
    {
        private PayPal.Api.Payment payment;
        public IConfiguration Configuration { get; }
        public IHttpContextAccessor httpContextAccessor { get; }
        public AppDBContext Context { get; }

        public PaymentController(IConfiguration configuration, IHttpContextAccessor context, AppDBContext _context)
        {
            Configuration = configuration;
            httpContextAccessor = context;
            Context = _context;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Payment/PaymentWithPaypal/{CartId:int}")]
        public ActionResult PaymentWithPaypal(int CartId, string Cancel = null, string blogId = "", string PayerID = "", string guid = "")
        {
            Cart? cart = Context.Carts.Include(C => C.Account).Include(c => c.CartItems).ThenInclude(ci => ci.Product)/*.Include(C => C.CartItems)*/.FirstOrDefault(C => C.Id == CartId);
            string? email = User.Claims.FirstOrDefault()?.Value;
            Models.Order.Order? order = Context.Orders.Find(httpContextAccessor?.HttpContext?.Session.GetInt32("order"));

            bool valid = false;
            if (cart != null && email != null)
            {
                // checking if cart account is the same as logged account
                if (cart.Account?.Email == email)
                    valid = true;
            }
            if (valid)
            {
                if (Cancel == null)
                {
                    //getting the apiContext  
                    var ClientID = Configuration.GetValue<string>("PayPal:Key");
                    var ClientSecret = Configuration.GetValue<string>("PayPal:Secret");
                    var mode = Configuration.GetValue<string>("PayPal:mode");
                    APIContext apiContext = PaypalConfiguration.GetAPIContext(ClientID, ClientSecret, mode);
                    // apiContext.AccessToken="Bearer access_token$production$j27yms5fthzx9vzm$c123e8e154c510d70ad20e396dd28287";
                    try
                    {
                        //A resource representing a Payer that funds a payment Payment Method as paypal  
                        //Payer Id will be returned when payment proceeds or click to pay  
                        string payerId = PayerID;
                        if (string.IsNullOrEmpty(payerId))
                        {
                            //this section will be executed first because PayerID doesn't exist  
                            //it is returned by the create function call of the payment class  
                            // Creating a payment  
                            // baseURL is the url on which paypal sendsback the data.  
                            string baseURI = this.Request.Scheme + "://" + this.Request.Host + $"/Payment/PaymentWithPayPal/{CartId}?";
                            //here we are generating guid for storing the paymentID received in session  
                            //which will be used in the payment execution  
                            var guidd = Convert.ToString((new Random()).Next(100000));
                            guid = guidd;
                            //CreatePayment function gives us the payment approval url  
                            //on which payer is redirected for paypal account payment  
                            var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid, cart);
                            //get links returned from paypal in response to Create function call  
                            var links = createdPayment.links.GetEnumerator();
                            string? paypalRedirectUrl = null;
                            while (links.MoveNext())
                            {
                                Links lnk = links.Current;
                                if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                                {
                                    //saving the payapalredirect URL to which user will be redirected for payment  
                                    paypalRedirectUrl = lnk.href;
                                }
                            }
                            // saving the paymentID in the key guid  
                            httpContextAccessor.HttpContext.Session.SetString("payment", createdPayment.id);
                            return Redirect(paypalRedirectUrl);
                        }
                        else
                        {

                            // This function exectues after receving all parameters for the payment  

                            var paymentId = httpContextAccessor.HttpContext.Session.GetString("payment");
                            var executedPayment = ExecutePayment(apiContext, payerId, paymentId as string);
                            //If executed payment failed then we will show payment failure message to user  
                            if (executedPayment.state.ToLower() != "approved")
                            {
                                order.OrderStatus = OrderStatus.Failed;
                                Context.SaveChanges();
                                return View("PaymentFailed");
                            }
                            //var blogIds = executedPayment.transactions[0].item_list.items[0].sku;
                            order = Context.Orders.Find(httpContextAccessor?.HttpContext?.Session.GetInt32("order"));
                            order.OrderStatus = OrderStatus.Completed;
                            cart.IsActive = false;
                            Context.SaveChanges();

                            return View("PaymentSuccess");
                        }
                    }
                    catch (Exception e)
                    {
                        order.OrderStatus = OrderStatus.Failed;
                        Context.SaveChanges();
                        return View("PaymentFailed");
                    }

                    return RedirectToAction("Index");
                    //on successful payment, show success page to user.  
                    return View("SuccessView");
                }
            }
            return RedirectToAction("Index");
        }

        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            this.payment = new Payment()
            {
                id = paymentId
            };
            return this.payment.Execute(apiContext, paymentExecution);
        }
        private Payment CreatePayment(APIContext apiContext, string redirectUrl, Cart cart)
        {
            //create itemlist and add item objects to it  

            var itemList = new ItemList()
            {
                items = new List<Item>()
            };

            //Adding Item Details like name, currency, price etc  
            //double totalPrice = 0;
            foreach (CartItem ci in cart.CartItems)
            {
                itemList.items.Add(new Item()
                {
                    name = ci.Product?.ProductName,
                    currency = "USD",
                    price = String.Format("{0:0.00}", ci.PriceAfterDiscount),
                    quantity = $"{ci.Quantity}",
                    sku = $"{ci.ProductSKU}"
                });
                //totalPrice += ci.PriceAfterDiscount*ci.Quantity;
            }

            //itemList.items.Add(new Item()
            //{
            //    name = "Item Detail",
            //    currency = "USD",
            //    price = "1.00",
            //    quantity = "1",
            //    sku = "asd"
            //});
            var payer = new Payer()
            {
                payment_method = "paypal"
            };
            // Configure Redirect Urls here with RedirectUrls object  
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };
            // Adding Tax, shipping and Subtotal details  
            //var details = new Details()
            //{
            //    tax = "1",
            //    shipping = "1",
            //    subtotal = "1"
            //};
            //Final amount with details  
            var amount = new Amount()
            {
                currency = "USD",
                total = String.Format("{0:0.00}", cart.GetTotalPrice())/*"1.00"*/, // Total must be equal to sum of tax, shipping and subtotal.  
                //details = details
            };
            var transactionList = new List<Transaction>();
            var invoicenum = Guid.NewGuid().ToString();
            //MVC_Project.Models.Order.Invoice invoice = new()
            //{
            //    InvoiceNumber = invoicenum,

            //};

            Models.Order.Invoice inv = new()
            {
                InvoiceNumber = invoicenum,
                TotalPaid = Convert.ToDecimal(cart.GetTotalPrice()),
                Currency = "USD",
            };
            Context.Add(inv);
            Context.SaveChanges();
            var user = Context.Accounts.FirstOrDefault(a => a.Id == cart.AccountId);
            Models.Order.Order order = new()
            {
                CustomerId = cart.AccountId,
                AddressId = user.SelectedAddressId,
                CartId = cart.Id,
                OrderStatus = OrderStatus.PendingPayment,
                PaymentMethod = PaymentMethod.Paypal,
                TotalPaid = cart.GetTotalPrice(),
                InvoiceId = inv.Id
            };

            Context.Orders.Add(order);
            Context.SaveChanges();
            httpContextAccessor.HttpContext.Session.SetInt32("order", order.Id);
            // Adding description about the transaction  
            transactionList.Add(new Transaction()
            {
                description = "Transaction description",
                invoice_number = invoicenum/*Guid.NewGuid().ToString()*/, //Generate an Invoice No  
                amount = amount,
                item_list = itemList
            });
            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            // Create a payment using a APIContext  
            return this.payment.Create(apiContext);
        }


    }
}
