namespace GymMe.Models
{
    public class TransactionDetail
    {
        public int TransactionID { get; set; }
        public int SupplementID { get; set; }
        public int Quantity { get; set; }

        public virtual TransactionHeader TransactionHeader { get; set; }
        public virtual MsSupplement Supplement { get; set; }
    }
}
