using System.Data.Entity.Migrations;
using Company.DataLayer;

namespace EntityFrameworkCodeFirst.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<CompanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CompanyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            // context.Brands.AddOrUpdate(new Models.Brand() { BrandID = 1, BrandName = "Samsung" });
            // context.Categories.AddOrUpdate(new Models.Category() { CategoryID = 1, CategoryName = "Electronics" });
            // context.Products.AddOrUpdate(new Models.Product() { ProductID = 1, ProductName = "Samsung Galaxy Mobile", CategoryID = 1, Dop = DateTime.Now, Active = true, BrandID = 1, Photo = null, Price = 450, AvailabilityStatus = "InStock" });
        }
    }
}
