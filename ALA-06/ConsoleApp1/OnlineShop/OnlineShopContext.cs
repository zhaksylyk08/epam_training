using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.OnlineShop
{
    class OnlineShopContext : DbContext
    {
        public OnlineShopContext()
        {

        }

        // Entities
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Pproducts { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                        .HasOptional(c => c.Comment)
                        .WithRequired(cart => cart.Customer);

            modelBuilder.Entity<Order>()
            .HasMany<Product>(o => o.Products)
            .WithMany(p => p.Orders);
        }
    }
}
