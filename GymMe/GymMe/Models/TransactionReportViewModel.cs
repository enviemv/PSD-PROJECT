using System;
using System.Collections.Generic;

namespace GymMe.Models
{
    public class TransactionReportViewModel
    {
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public List<TransactionDetailViewModel> TransactionDetails { get; set; }
    }
}
