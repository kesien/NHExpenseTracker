using Microsoft.EntityFrameworkCore;

namespace NExpenseTracker.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
