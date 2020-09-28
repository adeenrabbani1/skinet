using System.Linq;
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
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        //Personal note: We obviously need to tell the dbContext that we have
        //custome configurations to attach.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

           
           //Only for development purpose as sqlite doesnt support decimal types.
           
            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var props = entityType.ClrType.GetProperties()
                    .Where(p => p.PropertyType == typeof(decimal));

                    //once we have all props

                    foreach (var prop in props)
                    {
                        modelBuilder.Entity(entityType.Name).Property(prop.Name)
                        .HasConversion<double>();
                    }


                }
            }

        }
    }
}