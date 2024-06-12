using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymMe.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        public IActionResult ViewSupplements()
        {
            // Logic to view supplements
            return View();
        }

        public IActionResult OrderSupplement()
        {
            // Logic to order supplements
            return View();
        }

        public IActionResult ViewTransactionsHistory()
        {
            // Logic to view transaction history
            return View();
        }

        public IActionResult ViewTransactionDetail()
        {
            // Logic to view transaction details
            return View();
        }

        public IActionResult Profile()
        {
            // Logic to view profile
            return View();
        }

        public IActionResult UpdateProfile()
        {
            // Logic to update profile
            return View();
        }

        public IActionResult History()
        {
            return View();
        }
    }
}
