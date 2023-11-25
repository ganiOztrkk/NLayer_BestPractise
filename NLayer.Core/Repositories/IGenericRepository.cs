using System.Linq.Expressions;

namespace NLayer.Core.Repositories;

public interface IGenericRepository<T> 
    where T: class, new()
{
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void Update(T entity);
    Task<T> GetByIdAsync(int id);
    IQueryable<T> GetAll();
    IQueryable<T> Where(Expression<Func<T,bool>> expression);
    Task<bool> AnyAsync(Expression<Func<T,bool>> expression);
    
    //update ve remove metotlarının ef tarafında asenkron metotları yok. çünkü bunlar uzun süren işlemler degil. add metodunda oldugu gibi bloklanmaması gereken bir thread yok. update ve remove metotlarında entity zaten memoryde takip edilen entityler oluyor. update ya da remove dedigimizde saaadece memoryde takipte olan bu entitylerin stateleri değişir. Add memorye bir veri kaydediyor uzun bir islem thread bloklanmaması lazım bu yuzden asenkron var fakat remove ve update cok kısa islemler oldugu icin asenkron calısmasına gerek yok. asenkron metotlar ile var olan threadler iş ile bloklanmaz daha efektif kullanılır.
}