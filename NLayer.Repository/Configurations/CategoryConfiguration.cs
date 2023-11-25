using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);//primary key isaretledik.
        builder.Property(x => x.Id).UseIdentityColumn();//id degeri default olarak 1den baslar 1er artar.
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);//name boş geçilmesin ve maksimum 50 karakter olsun
        builder.ToTable("Categories");//tablo adını açık açık yazdık. istediğini yazabilirsin.  bunu vermezsen dbsetteki ismi alır.
    }
}