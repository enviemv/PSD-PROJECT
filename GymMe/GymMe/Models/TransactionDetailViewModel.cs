using System;

namespace GymMe.Models
{
    public class TransactionDetailViewModel
    {
        public string SupplementName { get; set; }
        public decimal SupplementPrice { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
    }
}
