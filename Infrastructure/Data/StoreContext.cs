using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

//using entitiy framework for the database wrapping and
//decoupling the database to the rest of the code
//we have extend from Dbcontext and all the Dbset<Tentity> for all of our
//entities will be declared here.
namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        //Personal note: We obviously need to tell the dbContext
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}