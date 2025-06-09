using JJ.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;

namespace JJ.INFRASTRUCTURE.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new { Id = 1, Name = "Notebook Gamer X", Price = 7499.90m, ImageUrl = "https://placehold.co/300x200/3b82f6/white?text=Notebook+SQL" },
                new { Id = 2, Name = "Mouse Pro Gamer", Price = 129.50m, ImageUrl = "https://placehold.co/300x200/ef4444/white?text=Mouse+SQL" },
                new { Id = 3, Name = "Teclado Mecânico Avançado", Price = 499.00m, ImageUrl = "https://placehold.co/300x200/22c55e/white?text=Teclado+SQL" },
                new { Id = 4, Name = "Monitor UltraWide 34\"", Price = 2899.99m, ImageUrl = "https://placehold.co/300x200/6366f1/white?text=Monitor+SQL" },
                new { Id = 5, Name = "Headset Gamer Imersivo", Price = 350.00m, ImageUrl = "https://placehold.co/300x200/ec4899/white?text=Headset+SQL" }
            );
        }
    }
}
