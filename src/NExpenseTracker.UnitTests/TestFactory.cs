using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NExpenseTracker.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NExpenseTracker.UnitTests
{
    public class TestFactory : IDisposable
    {
        public readonly DbContextOptions<ApplicationDbContext> Options;
        private readonly SqliteConnection _connection;

        public TestFactory()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            Options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(_connection)
                .Options;
        }

        public void Initialize()
        {
            _connection.Open();
            using var context = new ApplicationDbContext(Options);
            context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            using var context = new ApplicationDbContext(Options);
            context.Database.EnsureDeleted();
            _connection.Dispose();
        }
    }
}
