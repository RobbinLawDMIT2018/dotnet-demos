//https://docs.microsoft.com/en-us/ef/core/

using Microsoft.EntityFrameworkCore;
using Entities;

namespace DAL 
{
    public class Context : DbContext {
        //constructor dependancy injection
        //inject the options which will tell the database context class where to access the database
        public Context(DbContextOptions<Context> options)
            : base(options) {}
            
        public DbSet<BuildVersion>? BuildVersion { get; set; }
        // public DbSet<Category> Categories { get; set; }
        // public DbSet<Product> Products { get; set; }
        // public DbSet<Supplier> Suppliers { get; set; }
    }
}