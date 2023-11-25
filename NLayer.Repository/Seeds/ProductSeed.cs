using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Seeds;

public class ProductSeed : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product()
            {
                Id = 1, CategoryId = 1, Price = 100, Stock = 20, CreatedDate = DateTime.Now, Name = "Rotring" 
            },
            new Product()
            {
                Id = 2, CategoryId = 1, Price = 200, Stock = 30, CreatedDate = DateTime.Now, Name = "Faber" 
            },
            new Product()
            {
                Id = 3, CategoryId = 1, Price = 150, Stock = 15, CreatedDate = DateTime.Now, Name = "Mikro" 
            },
            new Product()
            {
                Id = 4, CategoryId = 2, Price = 400, Stock = 5, CreatedDate = DateTime.Now, Name = "Türklerin Tarihi" 
            },
            new Product()
            {
                Id = 5, CategoryId = 2, Price = 350, Stock = 8, CreatedDate = DateTime.Now, Name = "Türklerin Tarihi 2" 
            }
        );
    }
}