using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System;

namespace RepositoryLayer
{
    public class DbContextClass :DbContext /*IdentityDbContext*/
    {
        public DbSet<User> users { get; set; } // public so can be accessed in StoreRepositoryLayer.cs
        public DbSet<Location> locations { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Inventory> inventories { get; set; }
        public DbSet<Cart> carts { get; set; }

        public DbContextClass() { }
        public DbContextClass(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MelfsMagic_DB_MVC;Trusted_Connection=True;");
            // options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=RpsGame12142020;Trusted_Connection=True;");
        }
    }
}
