using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace ProductMangment.Model
{
    public class ProductContext: DbContext
    {
        public ProductContext():base()
        {

        }
        public IConfiguration Configuration;
        public ProductContext(DbContextOptions options):base(options)
        {

        }
 

        public virtual DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=.;Database=ProductDB;Trusted_Connection=True; MultipleActiveResultSets=true");

            }
        }
    }
}
