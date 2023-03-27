using eShop.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eShop.DataLayer
{
    public class eShopContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"); // Home
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
