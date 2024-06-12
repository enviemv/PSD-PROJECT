using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GymMe.Models
{
    public class User : IdentityUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public DateTime UserDOB { get; set; }
        public string UserGender { get; set; }
        public string UserRole { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public ICollection<TransactionHeader> Transactions { get; set; }
        public ICollection<Cart> Carts { get; set; }

        public User()
        {
            UserName = string.Empty;  // Default value to avoid null
            UserEmail = string.Empty;  // Default value to avoid null
            UserGender = string.Empty;  // Default value to avoid null
            UserRole = string.Empty;  // Default value to avoid null
            RowVersion = new byte[0];  // Default value to avoid null
            Transactions = new List<TransactionHeader>();  // Default value to avoid null
            Carts = new List<Cart>();  // Default value to avoid null
        }
    }
}
