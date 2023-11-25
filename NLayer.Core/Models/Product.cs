namespace NLayer.Core;

public class Product : BaseEntity
{
    public string Name { get; set; } 
    public int CategoryId { get; set; } // efcore bunu otomatik olarak foreign key olarak algılıyor.
    public int Stock { get; set; }
    public decimal Price { get; set; }

    public Category? Category { get; set; } //navigation property
    public ProductFeature ProductFeature { get; set; } // navigation property
}
//referans tipli degiskenlerin altını null deger uyarısı olarak ciziyor.
//value type degiskenlerin altını cizmez