using System;
using System.Collections.Generic;

namespace GymMe.Models
{
    public class TransactionHeader
    {
        public Guid Id { get; set; }  // This is the primary key
        public DateTime TransactionDate { get; set; }
        public string CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<TransactionDetail> TransactionDetails { get; set; }
        public User Customer { get; set; }
    }
}
