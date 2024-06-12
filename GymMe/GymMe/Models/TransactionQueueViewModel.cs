using System;

namespace GymMe.Models
{
    public class TransactionQueueViewModel
    {
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsHandled { get; set; }
    }
}
