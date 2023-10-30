using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace ProductsAPI.Helpers
{
    public class DataContext: DbContext
    {
        public DbSet<Product> Products { get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=products.db;Cache=Shared");
        }
    }
}
