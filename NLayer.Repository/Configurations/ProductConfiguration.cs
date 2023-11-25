using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Stock).IsRequired();
        builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");//toplamda 18 katakter ama virgülden sonra 2 karakter. yani virgülden önce 16 sonra 2.
        builder.ToTable("Products");

        builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId); //productın 1 categorysi olabilir, kategorinin ise birden fazla productı olabilir. foreign key ise categoryid dir.
    }
}