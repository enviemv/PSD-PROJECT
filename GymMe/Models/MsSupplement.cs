using GymMe.Models;
using System.Collections.Generic;
using System;

public class MsSupplement
{
    public int SupplementID { get; set; }
    public string SupplementName { get; set; }
    public DateTime SupplementExpiryDate { get; set; }
    public decimal SupplementPrice { get; set; }
    public int SupplementTypeID { get; set; }

    public virtual MsSupplementType SupplementType { get; set; }
    public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }
    public virtual ICollection<MsCart> Carts { get; set; }

    
    public string SupplementDescription { get; set; }
}
