using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymMe.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewCustomers()
        {
            // Logic to view customers
            return View();
        }

        public IActionResult ManageSupplements()
        {
            // Logic to manage supplements
            return View();
        }

        public IActionResult ViewUnhandledOrders()
        {
            // Logic to view unhandled orders
            return View();
        }

        public IActionResult ViewHandledOrders()
        {
            // Logic to view handled orders
            return View();
        }

        public IActionResult HandleOrder()
        {
            // Logic to handle orders
            return View();
        }

        public IActionResult OrderQueue()
        {
            return View();
        }

        public IActionResult TransactionReport()
        {
            return View();
        }
    }
}
