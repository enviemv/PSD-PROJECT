using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GymMe.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserEmail { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string UserRole { get; set; }

        public virtual ICollection<TransactionHeader> TransactionHeaders { get; set; }
        public virtual ICollection<MsCart> Carts { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
