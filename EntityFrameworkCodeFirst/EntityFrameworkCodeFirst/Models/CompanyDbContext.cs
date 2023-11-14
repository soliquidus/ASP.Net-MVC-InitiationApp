using System.Data.Entity;

namespace EntityFrameworkCodeFirst.Models
{
    public class CompanyDbContext: DbContext
    {
        public CompanyDbContext(): base("dbConnectionString")
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}