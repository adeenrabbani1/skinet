using Core.Entities;
using Microsoft.EntityFrameworkCore;

//using entitiy framework for the database wrapping and
//decoupling the database to the rest of the code

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}