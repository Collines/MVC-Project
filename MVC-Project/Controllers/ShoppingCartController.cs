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
            Cart? cart = Context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Product).ThenInclude(p => p.Images).FirstOrDefault(C => C.AccountId.ToString() == User.Claims.FirstOrDefault().Value);
            return View(cart);
        }

        [Authorize]
        public IActionResult Checkout()
        {
            Cart? cart = Context.Carts
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Product)
                    .ThenInclude(p => p.Images)
                .Include(c => c.Account)
                    .ThenInclude(a => a.Addresses)
                .FirstOrDefault(C => C.AccountId.ToString() == (User.Claims.FirstOrDefault() != null ? User.Claims.First().Value : ""));

            return View(cart);
        }

        [Authorize]
        [HttpPost]

        public IActionResult UpdateCart(Dictionary<int, CartItem>? cartItems)
        {
            if (cartItems != null)
            {
                if (cartItems.Any())
                {
                    foreach (var item in cartItems.Values)
                    {
                        var cartItem = Context.CartItems.Find(item.Id);
                        if (cartItem != null)
                        {
                            if (item.Quantity > 0)
                            {
                                cartItem.Quantity = item.Quantity;
                            }
                            else
                            {
                                Context.Remove(cartItem);
                            }
                        }
                    }
                }
                Context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult RemoveCartItem(int id)
        {
            var cartItem = Context.CartItems.Find(id);
            if (cartItem != null)
            {
                Context.Remove(cartItem);
            }
            Context.SaveChanges();

            return RedirectToAction(nameof(Index));
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
                            CartItem? cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

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
                            cart.TotalPrice = cart.GetTotalPrice();
                            cart.DiscountedPrice = cart.GetDiscountedPrice();
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
                        else
                        {
                            cart = new()
                            {
                                AccountId = account.Id,
                                IsActive = true
                            };
                            Context.Add(cart);
                            Context.SaveChanges();
                            CartItem cartItem = new CartItem()
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
                            Context.SaveChanges();
                            cart.TotalPrice = cart.GetTotalPrice();
                            cart.DiscountedPrice = cart.GetDiscountedPrice();
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
                            CartItem? cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

                            if (cartItem != null)
                            {
                                if (cartItem.Quantity > 1)
                                    cartItem.Quantity--;
                                else
                                    Context.Remove(cartItem);
                            }

                            cart.TotalPrice = cart.GetTotalPrice();
                            cart.DiscountedPrice = cart.GetDiscountedPrice();

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

        public IActionResult AddAddress(Address address)
        {
            var claims = User.Claims;
            var claimId = claims.FirstOrDefault();
            string accountId = claimId != null ? claimId.Value : "";

            Account? account = Context.Accounts.Include(a => a.Addresses).FirstOrDefault(a => a.Id.ToString() == accountId);

            address.AccountId = int.Parse(accountId);
            if (!account.Addresses.Any())
            {
                address.IsDefault = true;
            }

            account?.Addresses.Add(address);
            Context.SaveChanges();

            return RedirectToAction("Checkout");
            // return Json(new { success = true, html = PartialView("_AddressesList", account?.Addresses).ToString() });
        }
    }
}
