using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.DTOs;
using MVC_Project.Helpers;
using MVC_Project.Models.Cart;
using MVC_Project.Models.Identity;
using shopping.Models;

namespace MVC_Project.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        public ShoppingCartController(AppDBContext context)
        {
            Context = context;
        }

        public AppDBContext Context { get; }

        public IActionResult Index()
        {
            Account? owner = Context.Accounts.FirstOrDefault(A => A.Email == User.Claims.FirstOrDefault().Value);
            Cart cart = Context.Carts.Include(c=>c.CartItems).ThenInclude(ci=>ci.Product).ThenInclude(p=>p.Images).FirstOrDefault(C => C.AccountId == owner.Id);
            return View(cart);
        }        
        public IActionResult Checkout()
        {
            Account? owner = Context.Accounts.FirstOrDefault(A => A.Email == User.Claims.FirstOrDefault().Value);
            Cart cart = Context.Carts.Include(c=>c.CartItems).ThenInclude(ci=>ci.Product).ThenInclude(p=>p.Images).FirstOrDefault(C => C.AccountId == owner.Id);
            return View(cart);
        }

        [HttpPost("ShoppingCart/AddToCart/{productId:int}")]
        public IActionResult AddToCart(int productId)
        {
            Account? owner = Context.Accounts.FirstOrDefault(A => A.Email == User.Claims.FirstOrDefault().Value); // getting logged user
            Cart? cart = Context.Carts.Include(c=>c.CartItems).FirstOrDefault(C => C.AccountId == owner.Id); // getting logged user cart if he has one
            Product? product = Context.Products.Include(P=>P.Images).FirstOrDefault(P=>P.ProductId== productId); // getting added to cart product
            CartItem cartItem = null;
            //double cartTotalPrice = 0;
            bool alreadyExist = false;
            ShoppingCartDTO results;
            if (cart == null) // if logged user has no cart, create one
            {
                cart = new Cart()
                {
                    AccountId = owner.Id,
                    IsActive = true,
                    AddressId = owner.SelectedAddressId
                };
                if(product!=null)
                {
                    cartItem = new CartItem()
                    {
                        ProductId = product.ProductId,
                        Quantity = 1,
                        Price = product.Price,
                        Discount = product.Discount,
                        PriceAfterDiscount = product.PriceAfterDiscount(),
                        DiscountedPrice = product.DiscountedAmount(),
                        ProductSKU = product.SKU,
                        CartId = cart.Id,
                    };
                    //cartTotalPrice += cartItem.PriceAfterDiscount * cartItem.Quantity;
                    cart.CartItems.Add(cartItem);
                    Context.Add(cart);
                    Context.SaveChanges();
                    results = new ShoppingCartDTO
                    {
                        Message = $"{product.ProductName} has beed Added to your cart!",
                        CartCount = cart.CartItems.Count(),
                        PriceAfterDiscount = cartItem?.PriceAfterDiscount ?? 0,
                        CartTotalPrice = cart.GetTotalPrice(),
                        ProductId = productId,
                        ProductName = product.ProductName,
                        Quantity = cartItem?.Quantity ?? 0,
                        ImageURI = ImageHandler.GetImageURI(product.GetMainImage())
                    };
                    return Json(results);
                }

            } 
            else
            {
                if (product != null)
                {
					if (cart.CartItems.Count > 0)
					{
						foreach (CartItem ci in cart.CartItems)
						{
							if (ci.ProductId == productId)
							{
								ci.Quantity += 1;
								cartItem = ci;
								alreadyExist = true;
								//cartTotalPrice += ci.PriceAfterDiscount;
                                Context.SaveChanges();
                                results = new ShoppingCartDTO
                                {
                                    Message = $"{product.ProductName} has beed Added to your cart!",
                                    CartCount = cart.CartItems.Count(),
                                    PriceAfterDiscount = cartItem?.PriceAfterDiscount ?? 0,
                                    CartTotalPrice = cart.GetTotalPrice(),
                                    ProductId = productId,
                                    ProductName = product.ProductName,
                                    Quantity = cartItem?.Quantity ?? 0,
                                    ImageURI = ImageHandler.GetImageURI(product.GetMainImage())
                                };
                                return Json(results);

							}
						}
					}
					if (!alreadyExist)
					{
						cartItem = new CartItem()
						{
							ProductId = product.ProductId,
							Quantity = 1,
							Price = product.Price,
							Discount = product.Discount,
							PriceAfterDiscount = product.PriceAfterDiscount(),
							DiscountedPrice = product.DiscountedAmount(),
							ProductSKU = product.SKU,
							CartId = cart.Id,
						};
						//cartTotalPrice += cartItem.PriceAfterDiscount * cartItem.Quantity;
						cart.CartItems.Add(cartItem);

					}
					Context.SaveChanges();
					results = new ShoppingCartDTO
					{
						Message = $"{product.ProductName} has beed Added to your cart!",
						CartCount = cart.CartItems.Count(),
						PriceAfterDiscount = cartItem?.PriceAfterDiscount ?? 0,
						CartTotalPrice = cart.GetTotalPrice(),
						ProductId = productId,
						ProductName = product.ProductName,
						Quantity = cartItem?.Quantity ?? 0,
						ImageURI = ImageHandler.GetImageURI(product.GetMainImage())
					};
					return Json(results);
				}

            }
             results = new ShoppingCartDTO
            {
                Message = $"Product not found",
                CartCount = cart?.CartItems.Count ?? 0,
            };
            return Json(results);
        }

        [HttpPost("ShoppingCart/RemoveFromCart/{productId:int}")]
        public IActionResult RemoveFromCart(int productId)
        {
            Account? owner = Context.Accounts.FirstOrDefault(A => A.Email == User.Claims.FirstOrDefault().Value);
            Cart cart = Context.Carts.Include(c=>c.CartItems).FirstOrDefault(C => C.AccountId == owner.Id);
            Product? product = Context.Products.Find(productId);
            CartItem cartItem = null;
            double cartTotalPrice = 0;
            if (cart != null && product != null)
            {
                foreach (CartItem ci in cart.CartItems)
                {
                    if (ci.ProductId == productId) { }
                        cartItem = ci;
                    cartTotalPrice += ci.PriceAfterDiscount*ci.Quantity;
                }
                if (cartItem != null)
                {
                    if(cartItem.Quantity > 1)
                    {
                        cartItem.Quantity -= 1;
                    } else
                    {
                        Context.Remove(cartItem);
                    }
                }
                Context.SaveChanges();
                var results = new ShoppingCartDTO
                {
                    Message = $"{product.ProductName} has beed Removed from your cart!",
                    CartCount = cart.CartItems.Count(),
                    CartTotalPrice = cart.GetTotalPrice(),
                };
                return Json(results);

            }
            else
            {
                var results = new ShoppingCartDTO
                {
                    Message = $"Product not found",
                    CartCount = cart?.CartItems.Count() ?? 0,
                };
                return Json(results);
            }
        }
    }
}
