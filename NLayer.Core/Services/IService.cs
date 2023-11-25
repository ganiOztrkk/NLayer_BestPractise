using System.Linq.Expressions;

namespace NLayer.Core.Services;

public interface IService<T> where T: class, new()
{
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
    Task RemoveAsync(T entity);
    Task RemoveRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    IQueryable<T> Where(Expression<Func<T,bool>> expression);
    Task<bool> AnyAsync(Expression<Func<T,bool>> expression);
    //remove ve update metotlarında generic repo tarafında void dönerken burada task dönüyoruz. çünkü iservice ile bu metotları veritabanına yansıtacağımız için savechangesasync metodunu kullanacagız. bu yzuden task ile isaretliyoruz.
}