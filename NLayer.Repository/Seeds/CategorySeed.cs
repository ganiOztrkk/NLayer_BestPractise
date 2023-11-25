using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Seeds;

public class CategorySeed : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        //seed data esnasında normal veritabanı ekleme işleminden farklı olarak verilere id değeri manuel olarak atanır.

        builder.HasData(
            new Category { Id = 1, Name = "Kalemler" },
            new Category { Id = 2, Name = "Kitaplar" },
            new Category { Id = 3, Name = "Defterler" }
        );
    }
}