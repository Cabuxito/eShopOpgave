using eShop.DataLayer.Entities;
using eShop.DataLayer.Entities.JoinerTables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eShop.DataLayer
{
    public class eShopContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<ZipCode> ZipCodes { get; set; }

        public eShopContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
                
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"); // School
                //.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"); // Home
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region FLUENT API

            //Many-to-Many Ghost Table


            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .UsingEntity(j => j.ToTable("CategoryProducts"));

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithMany(o => o.Customer)
                .UsingEntity(j => j.ToTable("OrderCustomers"));

            //Many - to - Many Physycs table

            modelBuilder.Entity<OrderProduct>()
                .HasOne(p => p.Orders)
                .WithMany(o => o.Products)
                .HasForeignKey(o => o.ProductId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(p => p.Products)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.OrdersId);

            modelBuilder.Entity<OrderProduct>()
                .HasKey(p => new
                {
                    p.OrdersId, p.ProductId
                });

            #endregion
        }
    }
}
