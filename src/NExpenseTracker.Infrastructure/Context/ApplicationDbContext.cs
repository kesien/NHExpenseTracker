using Microsoft.EntityFrameworkCore;
using NExpenseTracker.Api.Entities;

namespace NExpenseTracker.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            _ = modelBuilder.Entity<TransactionEntity>().HasKey(e => e.Id);

            _ = modelBuilder.Entity<InvoiceEntity>().HasKey(e => e.Id);
            _ = modelBuilder.Entity<InvoiceEntity>()
                .HasMany(e => e.Transactions)
                .WithOne(e => e.Invoice)
                .HasForeignKey(e => e.InvoiceId);
        }

        public DbSet<InvoiceEntity> Invoices { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
