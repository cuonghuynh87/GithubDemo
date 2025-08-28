using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed User Data
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { Id = 1, Name = "User1", Email = "User1@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("P@ssW@rd1") },
                new ApplicationUser { Id = 2, Name = "User2", Email = "User2@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("P@ssW@rd2") }
            );
            // Seed Product Data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = Guid.NewGuid(), Name = "Product1", Description = "Description1", ImageUrl ="Image1", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
                new Product { Id = Guid.NewGuid(), Name = "Product2", Description = "Description2", ImageUrl = "Image2", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now }
            );
        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
