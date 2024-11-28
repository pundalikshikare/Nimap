using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace nimap_company.Models
{
    public class DataContext : DbContext
    {

        public DataContext()
            : base("name=DbConnectionString")
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                        .HasRequired(p => p.Categories)         
                        .WithMany(c => c.Products)           
                        .HasForeignKey(p => p.CategoryId);    

            base.OnModelCreating(modelBuilder);
        }

    }
}