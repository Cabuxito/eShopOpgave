using eShop.DataLayer.Entities;
using eShop.DataLayer.Entities.JoinerTables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Flurl.Http;
using eShop.DataLayer.JsonAPI;

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
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region FLUENT API

            //OrderCustomersss

            modelBuilder.Entity<OrderCustomer>()
                .HasOne(o => o.Orders)
                .WithMany(c => c.Customers)
                .HasForeignKey(x => x.CustomerId);

            modelBuilder.Entity<OrderCustomer>()
                .HasOne(c => c.Customers)
                .WithMany(o => o.Orders)
                .HasForeignKey(x => x.OrdersId);

            modelBuilder.Entity<OrderCustomer>()
                .HasKey(x => new
                {
                    x.OrdersId,
                    x.CustomerId
                });



            //CategoryProducts
            modelBuilder.Entity<CategoryProducts>()
                .HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<CategoryProducts>()
                .HasOne(p => p.Products)
                .WithMany(c => c.Category)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<CategoryProducts>()
                .HasKey(p => new
                {
                    p.CategoryId,
                    p.ProductId
                });


            // OrdeProducts
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
                    p.OrdersId,
                    p.ProductId
                });

            #endregion

            #region Data Seeding

            for (int i = 0; i < 7 ; i++)
            {
                modelBuilder.Entity<Product>().HasData(
                   new Product
                   {
                       ProductId = 1 + i,
                       Title = "Game",
                       Description = "this game is awesome",
                       Price = 1 + i,
                       Stock = 100,
                       Manufacture = "Blizzard",
                       ImageId = 1 + i,
                   });
            }

            //https://api.rawg.io/api/games?key=2dabb290f79c4df29a58fde8d38dfc34


            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Accion"},
                new Category { CategoryId = 2, Name = "Platform"},
                new Category { CategoryId = 3, Name = "Survival"},
                new Category { CategoryId = 4, Name = "Race"},
                new Category { CategoryId = 5, Name = "Horror"},
                new Category { CategoryId = 6, Name = "Maximus Prime"},
                new Category { CategoryId = 7, Name = "18+"}
                );

            modelBuilder.Entity<CategoryProducts>().HasData(
                new CategoryProducts { CategoryId = 1, ProductId= 1 },
                new CategoryProducts { CategoryId = 2, ProductId= 2 },
                new CategoryProducts { CategoryId = 3, ProductId= 3 },
                new CategoryProducts { CategoryId = 4, ProductId= 4 },
                new CategoryProducts { CategoryId = 5, ProductId= 5 },
                new CategoryProducts { CategoryId = 6, ProductId= 6 },
                new CategoryProducts { CategoryId = 7, ProductId= 7 }
                );

            for (int i = 0; i < 7; i++)
            {
                modelBuilder.Entity<Images>().HasData(
                    new Images { ImagesId = 1 + i, ImgPath = @"~\wwwroot\Images\DefaultImg.png", DefaultText = "Image not load", ProductId = 1 + i });
            }


            #endregion

            #region API
            List<PostNummerAPI> url = "https://api.dataforsyningen.dk/postnumre".GetJsonAsync<List<PostNummerAPI>>().GetAwaiter().GetResult();

            modelBuilder.Entity<ZipCode>()
                .HasData( url.Select(x => new ZipCode { ZipCodeId = Convert.ToInt32(x.nr), ZipCodeName = x.navn }).ToList());
            #endregion

        }
    }
}
