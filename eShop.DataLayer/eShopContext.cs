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
        public DbSet<Image> Images { get; set; }
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

            // Product

         

            //OrderCustomers

            modelBuilder.Entity<OrderCustomer>()
                .HasOne(o => o.Orders)
                .WithMany(c => c.Customers)
                .HasForeignKey(x => x.OrdersId);

            modelBuilder.Entity<OrderCustomer>()
                .HasOne(c => c.Customers)
                .WithMany(o => o.Orders)
                .HasForeignKey(x => x.CustomerId);

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
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<CategoryProducts>()
                .HasOne(p => p.Products)
                .WithMany(c => c.Category)
                .HasForeignKey(x => x.ProductId);

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
                .HasForeignKey(o => o.OrdersId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(p => p.Products)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<OrderProduct>()
                .HasKey(p => new
                {
                    p.ProductId,
                    p.OrdersId
                });

            #endregion

            #region Data Seeding

            for (int i = 0; i < 30 ; i++)
            {
                modelBuilder.Entity<Product>().HasData(
                   new Product
                   {
                       ProductId = 1 + i,
                       Title = "Diablo III",
                       Description = "Action role-playing game with fast-paced real-time combat and an isometric graphics engine. The game utilizes classic dark fantasy elements and players assume the role of a heroic character charged with saving the world of Sanctuary from the forces of Hell.",
                       Price = 69.99,
                       Stock = 100,
                       Manufacture = "Blizzard",
                       ImageId = 1 + i,
                   });
            }

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Accion"},
                new Category { CategoryId = 2, Name = "Platform"},
                new Category { CategoryId = 3, Name = "Survival"},
                new Category { CategoryId = 4, Name = "Race"},
                new Category { CategoryId = 5, Name = "Horror"},
                new Category { CategoryId = 6, Name = "Maximus Prime"},
                new Category { CategoryId = 7, Name = "18+"}
                );

            for (int i = 0; i < 30; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = 1 + i, ImgPath = @"/Images/diablo-3-pc-20394.png", DefaultText = "Image not load"});
            }

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerID = 1,
                Firstname = "Admin",
                Lastname = "Admin",
                Address = "Admin",
                Email = "admin@admin.com",
                Password = "admin",
                IsAdmin = true,
                IsDeleted = false,
                ZipCodeId = 1050,
            });
            
            modelBuilder.Entity<CategoryProducts>().HasData(
                new CategoryProducts { CategoryId = 1, ProductId = 1 },
                new CategoryProducts { CategoryId = 2, ProductId = 2 },
                new CategoryProducts { CategoryId = 3, ProductId = 3 },
                new CategoryProducts { CategoryId = 4, ProductId = 4 },
                new CategoryProducts { CategoryId = 5, ProductId = 5 },
                new CategoryProducts { CategoryId = 6, ProductId = 6 },
                new CategoryProducts { CategoryId = 7, ProductId = 7 },
                new CategoryProducts { CategoryId = 1, ProductId = 8 },
                new CategoryProducts { CategoryId = 2, ProductId = 9 },
                new CategoryProducts { CategoryId = 3, ProductId = 10 },
                new CategoryProducts { CategoryId = 4, ProductId = 11 },
                new CategoryProducts { CategoryId = 5, ProductId = 12 },
                new CategoryProducts { CategoryId = 6, ProductId = 13 },
                new CategoryProducts { CategoryId = 7, ProductId = 14 },
                new CategoryProducts { CategoryId = 1, ProductId = 15 },
                new CategoryProducts { CategoryId = 2, ProductId = 16 },
                new CategoryProducts { CategoryId = 3, ProductId = 17 },
                new CategoryProducts { CategoryId = 4, ProductId = 18 },
                new CategoryProducts { CategoryId = 5, ProductId = 19 },
                new CategoryProducts { CategoryId = 6, ProductId = 20 },
                new CategoryProducts { CategoryId = 7, ProductId = 21 },
                new CategoryProducts { CategoryId = 1, ProductId = 22 },
                new CategoryProducts { CategoryId = 2, ProductId = 23 },
                new CategoryProducts { CategoryId = 3, ProductId = 24 },
                new CategoryProducts { CategoryId = 4, ProductId = 25 },
                new CategoryProducts { CategoryId = 5, ProductId = 26 },
                new CategoryProducts { CategoryId = 6, ProductId = 27 },
                new CategoryProducts { CategoryId = 7, ProductId = 28 },
                new CategoryProducts { CategoryId = 1, ProductId = 29 },
                new CategoryProducts { CategoryId = 2, ProductId = 30 }
                );
            
            #endregion

            #region API
            List<PostNummerAPI> url = "https://api.dataforsyningen.dk/postnumre".GetJsonAsync<List<PostNummerAPI>>().GetAwaiter().GetResult();

            modelBuilder.Entity<ZipCode>()
                .HasData( url.Take(200).Select(x => new ZipCode { ZipCodeId = Convert.ToInt32(x.nr), ZipCodeName = x.navn }).ToList());

            #endregion

        }
    }
}
