using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Shop.DAL.Models;

namespace Shop.DAL
{
    public class ShopContext: DbContext
    {

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<ShopContext>(null);
        //    base.OnModelCreating(modelBuilder);
        //}



        public ShopContext() : base("Shop")
        {            
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Image> Images { get; set; }
    }
}