using GymMe.Extensions;
using GymMe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GymMe.Controllers
{
    public class OrderController : Controller
    {
        // Mock data for demonstration purposes. Replace with actual database calls.
        private static List<OrderSupplementViewModel> _supplements = new List<OrderSupplementViewModel>
        {
            new OrderSupplementViewModel { SupplementID = 1, SupplementName = "Vitamin C Supplement", SupplementExpiryDate = new DateTime(2025, 1, 1), SupplementPrice = 10000, SupplementTypeName = "Vitamin", Quantity = 0 },
            new OrderSupplementViewModel { SupplementID = 2, SupplementName = "Protein Powder Supplement", SupplementExpiryDate = new DateTime(2024, 1, 1), SupplementPrice = 20000, SupplementTypeName = "Protein", Quantity = 0 }
        };

        private const string CartSessionKey = "Cart";

        [HttpGet]
        public IActionResult OrderSupplement()
        {
            var model = new OrderSupplementListViewModel
            {
                Supplements = _supplements
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OrderSupplement(OrderSupplementListViewModel model)
        {
            if (!string.IsNullOrEmpty(model.CartAction))
            {
                var action = model.CartAction.Split('-');
                var actionName = action[0];
                var supplementId = int.Parse(action[1]);

                if (actionName == "Add")
                {
                    var supplement = _supplements.FirstOrDefault(s => s.SupplementID == supplementId);
                    if (supplement != null)
                    {
                        var quantity = model.Supplements.First(s => s.SupplementID == supplementId).Quantity;
                        if (quantity > 0)
                        {
                            AddToCart(supplement, quantity);
                        }
                    }
                }
            }

            if (model.CartAction == "ClearCart")
            {
                ClearCart();
            }
            else if (model.CartAction == "Checkout")
            {
                Checkout();
                return RedirectToAction("CheckoutConfirmation");
            }

            model.Supplements = _supplements;
            return View(model);
        }

        private void AddToCart(OrderSupplementViewModel supplement, int quantity)
        {
            var cart = GetCart();
            var cartItem = cart.FirstOrDefault(c => c.SupplementID == supplement.SupplementID);
            if (cartItem == null)
            {
                cartItem = new OrderSupplementViewModel
                {
                    SupplementID = supplement.SupplementID,
                    SupplementName = supplement.SupplementName,
                    SupplementExpiryDate = supplement.SupplementExpiryDate,
                    SupplementPrice = supplement.SupplementPrice,
                    SupplementTypeName = supplement.SupplementTypeName,
                    Quantity = quantity
                };
                cart.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }
            SaveCart(cart);
        }

        private void ClearCart()
        {
            HttpContext.Session.Remove(CartSessionKey);
        }

        private void Checkout()
        {
            var cart = GetCart();
            // Implement transaction creation logic here
            ClearCart();
        }

        private List<OrderSupplementViewModel> GetCart()
        {
            return HttpContext.Session.GetObjectFromJson<List<OrderSupplementViewModel>>(CartSessionKey) ?? new List<OrderSupplementViewModel>();
        }

        private void SaveCart(List<OrderSupplementViewModel> cart)
        {
            HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);
        }

        public IActionResult CheckoutConfirmation()
        {
            return View();
        }
    }
}
