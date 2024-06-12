using System;
using System.Collections.Generic;

namespace GymMe.Models
{
    public class TransactionHeader
    {
        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }
    }
}
