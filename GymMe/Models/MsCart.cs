namespace GymMe.Models
{
    public class MsCart
    {
        public int CartID { get; set; }
        public int UserID { get; set; }
        public int SupplementID { get; set; }
        public int Quantity { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual MsSupplement Supplement { get; set; }
    }
}
