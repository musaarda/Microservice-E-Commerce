using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 1,
            Name = "Samosa",
            Price = 15,
            Description = "Pleasent product 1...",
            ImageUrl = "https://madotnetmastery.blob.core.windows.net/mango/11.jpg",
            CategoryName = "Appetizer"
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 2,
            Name = "Paneer Tikka",
            Price = 13.99,
            Description = "Pleasent product 2...",
            ImageUrl = "https://madotnetmastery.blob.core.windows.net/mango/12.jpg",
            CategoryName = "Appetizer"
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 3,
            Name = "Sweet Pie",
            Price = 10.99,
            Description = "Pleasent product 3...",
            ImageUrl = "https://madotnetmastery.blob.core.windows.net/mango/13.jpg",
            CategoryName = "Dessert"
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 4,
            Name = "Pav Bhaji",
            Price = 15,
            Description = "Pleasent product 4...",
            ImageUrl = "https://madotnetmastery.blob.core.windows.net/mango/14.jpg",
            CategoryName = "Entree"
        });
    }

}
