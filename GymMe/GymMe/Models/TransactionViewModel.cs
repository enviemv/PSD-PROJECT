using System;
using System.Collections.Generic;

namespace GymMe.Models
{
    public class TransactionViewModel
    {
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public required string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsHandled { get; internal set; }
    }

    public class SupplementOrderDetailViewModel
    {
        public int SupplementID { get; set; }
        public required string SupplementName { get; set; }
        public decimal SupplementPrice { get; set; }
        public required string SupplementTypeName { get; set; }
        public int Quantity { get; set; } // Add Quantity property here
    }
}
