using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymMe.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<SupplementType> SupplementTypes { get; set; }
        public DbSet<TransactionHeader> TransactionHeaders { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Cart entity
            modelBuilder.Entity<Cart>()
                .HasKey(c => c.CartID);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany(u => u.Carts)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Supplement)
                .WithMany()
                .HasForeignKey(c => c.SupplementID)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Supplement entity
            modelBuilder.Entity<Supplement>()
                .HasKey(s => s.SupplementID);

            modelBuilder.Entity<Supplement>()
                .HasOne(s => s.SupplementType)
                .WithMany(st => st.Supplements)
                .HasForeignKey(s => s.SupplementTypeID)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure SupplementType entity
            modelBuilder.Entity<SupplementType>()
                .HasKey(st => st.SupplementTypeID);

            // Configure TransactionHeader entity
            modelBuilder.Entity<TransactionHeader>()
                .HasKey(th => th.Id);

            // Configure TransactionDetail entity
            modelBuilder.Entity<TransactionDetail>()
                .HasKey(td => td.Id);

            modelBuilder.Entity<TransactionHeader>()
                .HasMany(th => th.TransactionDetails)
                .WithOne(td => td.TransactionHeader)
                .HasForeignKey(td => td.TransactionHeaderId);
        }
    }
}
