using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GymMe.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<MsSupplement> Supplements { get; set; }
        public DbSet<MsSupplementType> SupplementTypes { get; set; }
        public DbSet<MsCart> Carts { get; set; }
        public DbSet<TransactionHeader> TransactionHeaders { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }

        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TransactionDetail>()
                .HasKey(td => new { td.TransactionID, td.SupplementID });

            modelBuilder.Entity<TransactionDetail>()
                .HasRequired(td => td.TransactionHeader)
                .WithMany(th => th.TransactionDetails)
                .HasForeignKey(td => td.TransactionID);

            modelBuilder.Entity<TransactionDetail>()
                .HasRequired(td => td.Supplement)
                .WithMany(s => s.TransactionDetails)
                .HasForeignKey(td => td.SupplementID);

            modelBuilder.Entity<MsCart>()
                .HasRequired(mc => mc.User)
                .WithMany(u => u.Carts)
                .HasForeignKey(mc => mc.UserID);

            modelBuilder.Entity<MsCart>()
                .HasRequired(mc => mc.Supplement)
                .WithMany(s => s.Carts)
                .HasForeignKey(mc => mc.SupplementID);
        }
    }
}
