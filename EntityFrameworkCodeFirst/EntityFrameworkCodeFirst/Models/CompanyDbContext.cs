﻿using System.Data.Entity;
using EntityFrameworkCodeFirst.Migrations;

namespace EntityFrameworkCodeFirst.Models
{
    public class CompanyDbContext: DbContext
    {
        public CompanyDbContext(): base("dbConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyDbContext, Configuration>());
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}