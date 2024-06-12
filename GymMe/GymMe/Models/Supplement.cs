namespace GymMe.Models
{
    public class Supplement
    {
        public int SupplementID { get; set; }
        public string SupplementName { get; set; }
        public DateTime SupplementExpiryDate { get; set; }
        public decimal SupplementPrice { get; set; }
        public int SupplementTypeID { get; set; }
        public SupplementType SupplementType { get; set; }
        public ICollection<TransactionDetail> TransactionDetails { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}
        