using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Erbosan.Entities.Concrete;

namespace Erbosan.DataAccess.Concrete.EntityFramework
{
   public class ErbosanContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=IPHONE;Database=Erbosan;Trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sales> Sales { get; set; }
    }
}
