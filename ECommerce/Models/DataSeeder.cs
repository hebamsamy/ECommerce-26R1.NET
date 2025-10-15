using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public static class DataSeeder
    {
        public static void SeedCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" , Description = ""},
                new Category { Id = 2, Name = "Books" ,Description = "" },
                new Category { Id = 3, Name = "Clothing" ,Description = "" },
                new Category { Id = 4, Name = "Home & Kitchen" , Description = "" },
                new Category { Id = 5, Name = "Food" , Description = "" }
            );
        }

        public static void SeedUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Admin", Email="admin@gmail.com" , PasswordHash="Asd@1234"},
                new User { Id = 2, Name = "ali", Email="ali@gmail.com" , PasswordHash="Asd@1234"},
                new User { Id = 3, Name = "ahmed", Email = "ahmed@gmail.com", PasswordHash = "Asd@1234",
                }
            );
        }
        public static void SeedSupplier(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier
                {
                    UserId = 3,
                    ShopName = "Tech Supplies Co.",
                    ShopLogo = "https://example.com/logo.png",
                    ShopLocation = "Sahary, Aswan"
                });
        }
        public static void SeedProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Description = "A high-performance laptop", Price = 999.99m, CategoryId = 1, SupplierId = 3 },
                new Product { Id = 2, Name = "Smartphone", Description = "A latest model smartphone", Price = 699.99m, CategoryId = 1, SupplierId = 3 },
                new Product { Id = 3, Name = "Tablet", Description = "A best-selling Tablet", Price = 1999.99m, CategoryId = 1, SupplierId = 3 },
                new Product { Id = 4, Name = "T-Shirt", Description = "A comfortable cotton t-shirt", Price = 14.99m, CategoryId = 3, SupplierId = 3 },
                new Product { Id = 5, Name = "Blender", Description = "A powerful kitchen blender", Price = 49.99m, CategoryId = 4, SupplierId = 3 }
            );
        }
    }

}
