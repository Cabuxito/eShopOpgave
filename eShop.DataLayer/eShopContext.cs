using eShop.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eShop.DataLayer
{
    public class eShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"); // Home
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region FLUENT API

            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);

            modelBuilder.Entity<Product>()
                .Property(p => p.Title);
            modelBuilder.Entity<Product>()
                .Property(p => p.Description);

            #endregion
        }
    }
}
