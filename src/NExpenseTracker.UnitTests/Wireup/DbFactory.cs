using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NExpenseTracker.UnitTests.Wireup
{
    public class DbFactory<T> where T : class
    {
        public IReadOnlyList<T> EntityList { get; }
        public DbFactory(in IReadOnlyList<T> entities)
        {
            EntityList = entities;
        }

        public async Task InitDbAsync(DbContext ctx)
        {
            await ctx.Database.EnsureCreatedAsync();

            await using (var tx = await ctx.Database.BeginTransactionAsync())
            {
                try
                {
                    var entityList = await ctx.Set<T>().ToListAsync();
                    foreach (var entity in entityList)
                    {
                        ctx.Remove(entity);
                    }

                    await ctx.SaveChangesAsync();
                    await tx.CommitAsync();
                }
                catch (Exception)
                {
                    await tx.RollbackAsync();
                    throw;
                }
            }

            await using (var tx = await ctx.Database.BeginTransactionAsync())
            {
                try
                {
                    foreach (var entity in EntityList)
                    {
                        await ctx.AddAsync(entity);
                    }

                    await ctx.SaveChangesAsync();
                    await tx.CommitAsync();
                    {

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await tx.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
