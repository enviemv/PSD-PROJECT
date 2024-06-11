using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymMe.Models
{
    public class SupplementController : Controller
    {
        // GET: Supplement
        public ActionResult Index()
        {
            return View();
        }
    }
}