using System;
using System.Collections.Generic;

namespace GymMe.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<TransactionDetail> TransactionDetails { get; set; }
        public User Customer { get; set; }
    }
}
