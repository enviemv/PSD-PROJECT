namespace GymMe.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public string UserId { get; set; } // Assuming UserId is a string to match AspNetUsers Id
        public int SupplementID { get; set; }
        public int Quantity { get; set; }

        public User User { get; set; }
        public Supplement Supplement { get; set; }
    }
}
