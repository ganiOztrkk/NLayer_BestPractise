namespace NLayer.Core;

public class ProductFeature // base entity almadık cunku burası zaten producta baglı. mesela prodcut icin createddate ne ise feature icin de gecerli. 1e1 ilişki var. her productın bir featuresi var. 
{
    public int Id { get; set; } // key
    public int ProductId { get; set; } // foreign key
    
    public string Color { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }

    public Product Product { get; set; } // navigation property
    
}