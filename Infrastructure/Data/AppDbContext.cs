
using Core.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Core.Models.OrderAggregate;
namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {   
        //specifiy option for one db context
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

        public DbSet<ProductBrand> productBrands { get; set; }
        public DbSet<ProductType> productTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
            new Product

            {
                ProductId = 1,
                Name = "Angular Speedster Board 2000",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 200,
                PictureUrl = "images/products/sb-ang1.png",
                ProductTypeId = 26,
                ProductBrandId = 37
            }, new Product
            {
                ProductId = 2,
                Name = "Green Angular Board 3000",
                Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                Price = 150,
                PictureUrl = "images/products/sb-ang2.png",
                ProductTypeId = 25,
                ProductBrandId = 37
            }, new Product
            {
                ProductId = 3,
                Name = "Core Board Speed Rush 3",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 180,
                PictureUrl = "images/products/sb-core1.png",
                ProductTypeId = 26,
                ProductBrandId = 39
            }, new Product
            {
                ProductId = 4,
                Name = "Net Core Super Board",
                Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                Price = 300,
                PictureUrl = "images/products/sb-core2.png",
                ProductTypeId = 26,
                ProductBrandId = 39
            }, new Product
            {
                ProductId = 5,
                Name = "React Board Super Whizzy Fast",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 250,
                PictureUrl = "images/products/sb-react1.png",
                ProductTypeId = 25,
                ProductBrandId = 40
            }, new Product
            {
                ProductId = 6,
                Name = "Typescript Entry Board",
                Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                Price = 120,
                PictureUrl = "images/products/sb-ts1.png",
                ProductTypeId = 25,
                ProductBrandId = 41
            }, new Product
            {
                ProductId = 19,
                Name = "Core Blue Hat",
                Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 10,
                PictureUrl = "images/products/hat-core1.png",
                ProductTypeId = 26,
                ProductBrandId = 38
            }, new Product
            {
                ProductId = 7,
                Name = "Green React Woolen Hat",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 8,
                PictureUrl = "images/products/hat-react1.png",
                ProductTypeId = 26,
                ProductBrandId = 40
            }, new Product
            {
                ProductId = 8,
                Name = "Purple React Woolen Hat",
                Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 15,
                PictureUrl = "images/products/hat-react2.png",
                ProductTypeId = 26,
                ProductBrandId = 40
            }, new Product
            {
                ProductId = 9,
                Name = "Blue Code Gloves",
                Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                Price = 18,
                PictureUrl = "images/products/glove-code1.png",
                ProductTypeId = 28,
                ProductBrandId = 39
            }, new Product
            {
                ProductId = 10,
                Name = "Green Code Gloves",
                Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                Price = 15,
                PictureUrl = "images/products/glove-code2.png",
                ProductTypeId = 28,
                ProductBrandId = 39
            }, new Product
            {
                ProductId = 20,
                Name = "Purple React Gloves",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.",
                Price = 16,
                PictureUrl = "images/products/glove-react1.png",
                ProductTypeId = 28,
                ProductBrandId = 40
            }, new Product
            {
                ProductId = 11,
                Name = "Green React Gloves",
                Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                Price = 14,
                PictureUrl = "images/products/glove-react2.png",
                ProductTypeId = 28,
                ProductBrandId = 40
            }, new Product
            {
                ProductId = 12,
                Name = "Redis Red Boots",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 250,
                PictureUrl = "images/products/boot-redis1.png",
                ProductTypeId = 27,
                ProductBrandId = 42
            }, new Product
            {
                ProductId = 13,
                Name = "Core Red Boots",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 189,
                PictureUrl = "images/products/boot-core2.png",
                ProductTypeId = 27,
                ProductBrandId = 39
            }, new Product
            {
                ProductId = 14,
                Name = "Core Purple Boots",
                Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                Price = 199,
                PictureUrl = "images/products/boot-core1.png",
                ProductTypeId = 27,
                ProductBrandId = 38
            }, new Product
            {
                ProductId = 15,
                Name = "Angular Purple Boots",
                Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                Price = 150,
                PictureUrl = "images/products/boot-ang2.png",
                ProductTypeId = 27,
                ProductBrandId = 37
            }, new Product
            {
                ProductId = 16,
                Name = "Angular Blue Boots",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 180,
                PictureUrl = "images/products/boot-ang1.png",
                ProductTypeId = 27,
                ProductBrandId = 39
            });





            modelBuilder.Entity<DeliveryMethod>().HasData(
            new DeliveryMethod{
     DeliveryMethodId = 1,          
    ShortName= "UPS1",
    Description= "Fastest delivery time",
    DeliveryTime= "1-2 Days",
    Price= "10"
  }, new DeliveryMethod
  {
      DeliveryMethodId = 2,
      ShortName = "UPS2",
    Description= "Get it within 5 days",
    DeliveryTime= "2-5 Days",
    Price= "5"
  }, new DeliveryMethod
  {DeliveryMethodId = 3,

    ShortName= "UPS3",
    Description= "Slower but cheap",
    DeliveryTime= "5-10 Days",
    Price= "2"
  }, new DeliveryMethod
  {
      DeliveryMethodId = 4,
      ShortName = "FREE",
    Description= "Free! You get what you pay for",
    DeliveryTime= "1-2 Weeks",
    Price= "free"
  }
                            );

        }
    }
}
