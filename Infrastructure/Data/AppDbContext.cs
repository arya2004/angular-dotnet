﻿
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
            modelBuilder.Entity<Order>()
        .HasOne(o => o.DeliveryMethod)
        .WithMany();
        
            modelBuilder
        .Entity<DeliveryMethod>(
            eb =>
            {
                eb.HasNoKey();
                eb.ToView("View_DeliveryMethod");
            });


            modelBuilder.Entity<DeliveryMethod>().HasData(
            new DeliveryMethod{
               
    ShortName= "UPS1",
    Description= "Fastest delivery time",
    DeliveryTime= "1-2 Days",
    Price= "10"
  }, new DeliveryMethod
  {
               
    ShortName= "UPS2",
    Description= "Get it within 5 days",
    DeliveryTime= "2-5 Days",
    Price= "5"
  }, new DeliveryMethod
  {
    ShortName= "UPS3",
    Description= "Slower but cheap",
    DeliveryTime= "5-10 Days",
    Price= "2"
  }, new DeliveryMethod
  {
                
    ShortName= "FREE",
    Description= "Free! You get what you pay for",
    DeliveryTime= "1-2 Weeks",
    Price= "free"
  }
                            );

        }
    }
}
