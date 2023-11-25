using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using NLayer.Core;
using NLayer.Repository.Configurations;

namespace NLayer.Repository;

public class AppDbContext : DbContext
{
    //neden ctor inşa ettik ve dbcontextoptions aldı? çünkü ben bu options ile beraber veritabanı yolunu middleware tarafında yani program.cs de ya da startup dosyamda vericem. 
    public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductFeature> ProductFeatures { get; set; }//burada şunu diyebilirdik, product feature tek başına erişilebilir ve işlem yapılabilir bir tablo olmasın. mutlaka product ile beraber eklenen ve işlem gören bir yapı olsun.
    //bu durumda productfeature satırını dbset olarak geçmezdik ve productfeatureye product nesnesi üzerinden newleyerek erişip işlem yapardık.
    

    protected override void OnModelCreating(ModelBuilder modelBuilder) //entity configürasyon metodum. database oluşturulurken entitylerim bu ayarlara göre config edilsin.
    {
        //modelBuilder.Entity<Category>().HasKey(x => x.Id);//primary key olarak id atadık. fakat bu işlemleri burada yaparsak bu sefer de burası çok kirlenecek. bu yüzden her entitymiz ile ilgili configürasyonlarımızı ayrı classlarda tutalım.
        
        //biz özel olarak tüm configleri tanımladık ve şimdi efcore a bu configleri haber vermemiz lazım. bunun için;
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //applyconfigfromassemly metodu şunu diyor. git ve IEntityTypeConfiguration interfacesini implemente eden neresi varsa hepsini kontrol et.
        // Assembly.GetExecutingAssembly() === çalışmış olduğum assemblydeki tüm configler.
        
        //eğer tüm configleri taramasın özel olarak bir config git kontrol et demek istersem;
        //modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.Entity<ProductFeature>().HasData
        (
            new ProductFeature {Id = 1, Color = "Kırmızı", Height = 100, Width = 200, ProductId = 1},
            new ProductFeature {Id = 2, Color = "Siyah", Height = 100, Width = 200, ProductId = 2}
        );
        
        base.OnModelCreating(modelBuilder);
    }
}