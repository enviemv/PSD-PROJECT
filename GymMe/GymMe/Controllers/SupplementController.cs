using GymMe.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GymMe.Controllers
{
    public class SupplementController : Controller
    {
        // Mock data for demonstration purposes. Replace with actual database calls.
        private static List<SupplementViewModel> _supplements = new List<SupplementViewModel>
        {
            new SupplementViewModel { SupplementID = 1, SupplementName = "Vitamin C Supplement", SupplementExpiryDate = new DateTime(2025, 1, 1), SupplementPrice = 10000, SupplementTypeName = "Vitamin" },
            new SupplementViewModel { SupplementID = 2, SupplementName = "Protein Powder Supplement", SupplementExpiryDate = new DateTime(2024, 1, 1), SupplementPrice = 20000, SupplementTypeName = "Protein" }
        };

        [HttpGet]
        public IActionResult Manage()
        {
            return View(_supplements);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(SupplementViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SupplementID = _supplements.Max(s => s.SupplementID) + 1;
                _supplements.Add(model);
                return RedirectToAction("Manage");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var supplement = _supplements.FirstOrDefault(s => s.SupplementID == id);
            if (supplement == null)
            {
                return NotFound();
            }
            return View(supplement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(SupplementViewModel model)
        {
            if (ModelState.IsValid)
            {
                var supplement = _supplements.FirstOrDefault(s => s.SupplementID == model.SupplementID);
                if (supplement == null)
                {
                    return NotFound();
                }
                supplement.SupplementName = model.SupplementName;
                supplement.SupplementExpiryDate = model.SupplementExpiryDate;
                supplement.SupplementPrice = model.SupplementPrice;
                supplement.SupplementTypeName = model.SupplementTypeName;
                return RedirectToAction("Manage");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var supplement = _supplements.FirstOrDefault(s => s.SupplementID == id);
            if (supplement == null)
            {
                return NotFound();
            }
            _supplements.Remove(supplement);
            return RedirectToAction("Manage");
        }
    }
}
