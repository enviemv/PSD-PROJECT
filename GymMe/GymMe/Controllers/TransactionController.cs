using GymMe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace GymMe.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TransactionController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        // Declare the transactions list at the class level
        private static List<TransactionReportViewModel> _transactions = new List<TransactionReportViewModel>
        {
            new TransactionReportViewModel
            {
                TransactionID = 1,
                TransactionDate = new DateTime(2023, 6, 1),
                CustomerName = "John Doe",
                TotalAmount = 50.0m,
                TransactionDetails = new List<TransactionDetailViewModel>
                {
                    new TransactionDetailViewModel
                    {
                        SupplementName = "Vitamin C",
                        SupplementPrice = 10.0m,
                        Quantity = 3,
                        SubTotal = 30.0m
                    },
                    new TransactionDetailViewModel
                    {
                        SupplementName = "Protein Powder",
                        SupplementPrice = 20.0m,
                        Quantity = 1,
                        SubTotal = 20.0m
                    }
                }
            },
            new TransactionReportViewModel
            {
                TransactionID = 2,
                TransactionDate = new DateTime(2023, 6, 2),
                CustomerName = "Jane Smith",
                TotalAmount = 30.0m,
                TransactionDetails = new List<TransactionDetailViewModel>
                {
                    new TransactionDetailViewModel
                    {
                        SupplementName = "Vitamin C",
                        SupplementPrice = 10.0m,
                        Quantity = 1,
                        SubTotal = 10.0m
                    },
                    new TransactionDetailViewModel
                    {
                        SupplementName = "Protein Powder",
                        SupplementPrice = 20.0m,
                        Quantity = 1,
                        SubTotal = 20.0m
                    }
                }
            }
        };

        [HttpGet]
        public IActionResult Report()
        {
            return View(_transactions);
        }

        [HttpGet]
        public IActionResult GenerateReport()
        {
            var reportDocument = new ReportDocument();
            string reportPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "TransactionReport.rpt");
            reportDocument.Load(reportPath);
            reportDocument.SetDataSource(_transactions);

            // Export to PDF
            var stream = reportDocument.ExportToStream(ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "TransactionReport.pdf");
        }
    }
}
