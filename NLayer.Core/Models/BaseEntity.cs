namespace NLayer.Core;

public abstract class BaseEntity // bir nesne örneği alınmasın - sadece base class olsun
{
    public int Id { get; set; } // efcore bunu otomatik olarak primary key olarak algılıyor
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}