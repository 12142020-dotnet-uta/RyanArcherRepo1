using Microsoft.EntityFrameworkCore;
using System;

namespace MelfsMagic
{
    public class StoreDbContext : DbContext
    {

        public DbSet<User> users { get; set; } // public so can be accessed in StoreRepositoryLayer.cs
        public DbSet<Location> Locations { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Inventory> inventories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MelfsMagic_DB_Test1;Trusted_Connection=True;");
            // options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=RpsGame12142020;Trusted_Connection=True;");
        }

    }
}