using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=ASUS-SIFAT;Initial Catalog=ABG;Integrated Security=True;Persist Security Info=False;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Product 1", ProductDescription = "Description 1", ProductPrice = 10.0, ProductQuantity = 100 },
                new Product { ProductId = 2, ProductName = "Product 2", ProductDescription = "Description 2", ProductPrice = 20.0, ProductQuantity = 200 },
                new Product { ProductId = 3, ProductName = "Product 3", ProductDescription = "Description 3", ProductPrice = 30.0, ProductQuantity = 300 },
                new Product { ProductId = 4, ProductName = "Product 4", ProductDescription = "Description 4", ProductPrice = 40.0, ProductQuantity = 400 },
                new Product { ProductId = 5, ProductName = "Product 5", ProductDescription = "Description 5", ProductPrice = 50.0, ProductQuantity = 500 }
            );
        }
    }
}