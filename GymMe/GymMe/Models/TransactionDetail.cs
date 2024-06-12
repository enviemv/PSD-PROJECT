using System;

namespace GymMe.Models
{
    public class TransactionDetail
    {
        public Guid Id { get; set; }  // This is the primary key
        public Guid TransactionHeaderId { get; set; }
        public string SupplementName { get; set; }
        public decimal SupplementPrice { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public TransactionHeader TransactionHeader { get; set; }
    }
}
