using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prokhor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Data Source=localhost;Initial Catalog=ShopApp;Integrated Security=true");
            }
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //}

        public DbSet<Product> Products { get; set; }

        public DbSet<ShopBag> ShopBags { get; set; }

        public DbSet<Order> Orders { get; set; }

        internal void Add(Product product)
        {
            Products.Add(product);
            SaveChanges();
        }

        internal void Add(ShopBag shopBag)
        {
            ShopBags.Add(shopBag);
            SaveChanges();
        }

        internal Product FindProduct(int id)
        {
            return Products.AsQueryable().AsNoTracking().Where(p => p.Id == id).First();
        }

        internal Product UpdateProduct(Product product)
        {
            Products.Update(product);
            SaveChanges();
            return product;
        }

        internal bool FindAnyByIdAsync(int id)
        {
            return Products.Any(a => a.Id == id);
        }

        internal void RemoveIt(Product product)
        {
            Products.Remove(product);
            SaveChanges();
        }

        internal void RemoveIt(ShopBag shopBag)
        {
            ShopBags.Remove(shopBag);
            SaveChanges();
        }
        internal ShopBag FindShopBag(int id)
        {
            return ShopBags.AsQueryable().AsNoTracking().Where(p => p.ID == id).First();
        }

    }
}
