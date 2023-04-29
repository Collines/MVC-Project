using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            Cart cart = Context.Carts.FirstOrDefault(C => C.AccountId == owner.Id);
            return View(cart);
        }

        [HttpPost("ShoppingCart/AddToCart/{productId:int}")]
        public IActionResult AddToCart(int productId)
        {
            Account? owner = Context.Accounts.FirstOrDefault(A => A.Email == User.Claims.FirstOrDefault().Value);
            Cart cart = Context.Carts.FirstOrDefault(C => C.AccountId == owner.Id);
            Product? product = Context.Products.Find(productId);
            CartItem cartItem = null;
            decimal cartTotalPrice = 0;
            if (cart != null && product!=null)
            {
                bool alreadyExist = false;
                foreach(CartItem ci in cart.CartItems)
                {
                    if(ci.ProductId == productId)
                    {
                        ci.Quantity += 1;
                        cartItem = ci;
                        alreadyExist = true;
                        cartTotalPrice += ci.PriceAfterDiscount;

                    } else
                    cartTotalPrice += ci.PriceAfterDiscount*ci.Quantity;
                }
                if (!alreadyExist)
                {
                    cartItem = new CartItem()
                    {
                        ProductId = product.ProductId,
                        Quantity = 1,
                        Price = product.price,
                        Discount = 0,
                        PriceAfterDiscount = product.price,
                        DiscountedPrice = 0,
                        CartId = cart.Id,
                    };
                    cartTotalPrice += cartItem.PriceAfterDiscount * cartItem.Quantity;
                    cart.CartItems.Add(cartItem);
                    
                }
                Context.SaveChanges();
                var results = new ShoppingCartDTO
                {
                    Message = $"{product.ProductName} has beed Added to your cart!",
                    CartCount = cart.CartItems.Count(),
                    PriceAfterDiscount = cartItem?.PriceAfterDiscount ?? 0,
                    CartTotalPrice = cartTotalPrice,
                    ProductId = productId,
                    ProductName = product.ProductName,
                    Quantity = cartItem?.Quantity ?? 0,
                    ImageURI = ImageHandler.GetImageURI(product.Images.FirstOrDefault())
                };
                return Json(results);

            } else
            {
                var results = new ShoppingCartDTO
                {
                    Message = $"Product not found",
                    CartCount = cart?.CartItems.Count()??0,
                };
                return Json(results);
            }
        }

        [HttpPost("ShoppingCart/RemoveFromCart/{productId:int}")]
        public IActionResult RemoveFromCart(int productId)
        {
            Account? owner = Context.Accounts.FirstOrDefault(A => A.Email == User.Claims.FirstOrDefault().Value);
            Cart cart = Context.Carts.FirstOrDefault(C => C.AccountId == owner.Id);
            Product? product = Context.Products.Find(productId);
            CartItem cartItem = null;
            decimal cartTotalPrice = 0;
            if (cart != null && product != null)
            {
                foreach (CartItem ci in cart.CartItems)
                {
                    if (ci.ProductId == productId)
                        cartItem = ci;
                    cartTotalPrice += ci.PriceAfterDiscount*ci.Quantity;
                }
                if (cartItem != null)
                {
                    Context.Remove(cartItem);
                    cartTotalPrice -= cartItem.PriceAfterDiscount * cartItem.Quantity;
                }
                Context.SaveChanges();
                var results = new ShoppingCartDTO
                {
                    Message = $"{product.ProductName} has beed Removed from your cart!",
                    CartCount = cart.CartItems.Count(),
                    CartTotalPrice = cartTotalPrice
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
