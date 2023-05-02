using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [Authorize]
        public IActionResult Index()
        {
            Account? owner = Context.Accounts.FirstOrDefault(A => A.Id.ToString() == User.Claims.FirstOrDefault().Value);
            Cart cart = Context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Product).ThenInclude(p => p.Images).FirstOrDefault(C => C.AccountId == owner.Id);
            return View(cart);
        }

        [Authorize]
        public IActionResult Checkout()
        {
            Account? owner = Context.Accounts.FirstOrDefault(A => A.Id.ToString() == User.Claims.FirstOrDefault().Value);
            Cart cart = Context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Product).ThenInclude(p => p.Images).FirstOrDefault(C => C.AccountId == owner.Id);
            return View(cart);
        }

        [Authorize]
        [HttpPost("ShoppingCart/AddToCart_v2/{productId:int}")]
        public IActionResult AddToCart_v2(int productId)
        {
            Cart? cart = null;

            Product? product = Context.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                var claims = User.Claims;
                if (claims != null)
                {
                    var claimId = claims.FirstOrDefault();
                    string accountId = claimId != null ? claimId.Value : "";

                    Account? account = Context.Accounts.FirstOrDefault(a => a.Id.ToString() == accountId);

                    if (account != null)
                    {
                        cart = Context.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.AccountId == account.Id);

                        if (cart != null)
                        {
                            CartItem? cartItem = Context.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

                            if (cartItem != null)
                            {
                                cartItem.Quantity++;
                            }
                            else
                            {
                                cartItem = new CartItem()
                                {
                                    ProductId = product.ProductId,
                                    Quantity = 1,
                                    Price = product.Price,
                                    Discount = product.Discount,
                                    PriceAfterDiscount = product.PriceAfterDiscount(),
                                    DiscountedPrice = product.DiscountedAmount(),
                                    ProductSKU = product.SKU ?? "",
                                    CartId = cart.Id,
                                };

                                Context.CartItems.Add(cartItem);
                            }
                            Context.SaveChanges();

                            cart.TotalPrice = cart.CartItems.Sum(ci => ci.Price * ci.Quantity);
                            cart.DiscountedPrice = cart.CartItems.Sum(ci => ci.DiscountedPrice * ci.Quantity);

                            Context.SaveChanges();

                            var updatedCartItems = Context.CartItems.Where(ci => ci.CartId == cart.Id).Include(ci => ci.Product).ThenInclude(p => p.Images).Select(ci => new
                            {
                                id = ci.Id,
                                name = ci.Product.ProductName,
                                quantity = ci.Quantity,
                                priceAfterDiscount = ci.PriceAfterDiscount,
                                productId = ci.ProductId,
                                ImageURI = ImageHandler.GetImageURI(ci.Product.GetMainImage())
                            }).ToList();

                            var updatedCart = new
                            {
                                CartCount = cart.CartItems.Count,
                                CartTotalPrice = cart.GetTotalPrice(),
                                CartItems = updatedCartItems
                            };

                            return Json(updatedCart);
                        }
                    }
                }
            }

            var failed = new
            {
                CartCount = cart?.CartItems.Count ?? 0,
                CartTotalPrice = cart?.GetTotalPrice() ?? 0.0
            };
            return Json(failed);
        }

        [Authorize]
        [HttpPost("ShoppingCart/RemoveFromCart/{productId:int}")]
        public IActionResult RemoveFromCart(int productId)
        {
            Cart? cart = null;

            Product? product = Context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                var claims = User.Claims;
                if (claims != null)
                {
                    var claimId = claims.FirstOrDefault();
                    string accountId = claimId != null ? claimId.Value : "";

                    Account? account = Context.Accounts.FirstOrDefault(a => a.Id.ToString() == accountId);

                    if (account != null)
                    {
                        cart = Context.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.AccountId == account.Id);

                        if (cart != null)
                        {
                            CartItem? cartItem = Context.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

                            if (cartItem != null)
                            {
                                if (cartItem.Quantity > 1)
                                {
                                    cartItem.Quantity--;
                                }
                                else
                                {
                                    Context.Remove(cartItem);
                                }

                                Context.SaveChanges();
                            }

                            cart.TotalPrice = cart.CartItems.Sum(ci => ci.Price * ci.Quantity);
                            cart.DiscountedPrice = cart.CartItems.Sum(ci => ci.DiscountedPrice * ci.Quantity);

                            Context.SaveChanges();

                            var updatedCartItems = Context.CartItems.Where(ci => ci.CartId == cart.Id).Include(ci => ci.Product).ThenInclude(p => p.Images).Select(ci => new
                            {
                                id = ci.Id,
                                name = ci.Product.ProductName,
                                quantity = ci.Quantity,
                                priceAfterDiscount = ci.PriceAfterDiscount,
                                productId = ci.ProductId,
                                ImageURI = ImageHandler.GetImageURI(ci.Product.GetMainImage())
                            }).ToList();

                            var updatedCart = new
                            {
                                CartCount = cart.CartItems.Count,
                                CartTotalPrice = cart.GetTotalPrice(),
                                CartItems = updatedCartItems
                            };

                            return Json(updatedCart);
                        }
                    }
                }
            }

            var failed = new
            {
                CartCount = cart?.CartItems.Count ?? 0,
                CartTotalPrice = cart?.GetTotalPrice() ?? 0.0
            };
            return Json(failed);
        }
    }
}
