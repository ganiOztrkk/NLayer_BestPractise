using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories;

public class GenericRepository<T> : IGenericRepository<T> 
    where T:class, new()
{
    protected readonly AppDbContext _context; // protected olmasının sebebi, ilerde sadece entitye ozgu metodumuz olursa bu metotlar icin ayrı ayrı entityrepository leri oluşturmam gerek. haliyle bu entityrepolarda genericrepo muzu miras alıp buradaki contexte erişebilmemiz gerek. protected miras alındığı sınıflardan erişilebilir.
    private readonly DbSet<T> _dbSet; //tablolarımı tutacak

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity); //sadece entitynin statesi deleted olarak işaretlendi. flag atıldı. ne zaman savechanges cagırılır, o zaman dbden ilgili veri silinir. yüklü bir iş degil basit bir iş, asenkron gerekmez.
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return (await _dbSet.FindAsync(id))!; //findasync metodu direkt olarak bizden bir primary key bekler.
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet.AsNoTracking().AsQueryable();
        //asnotracking -- ef core track ettigi dataları memorye almasın, daha perf calıssın. eger bunu kullanmazsak cekilen ne kadar data varsa hepsi memorye cekilir ve hepsi izlenir. uygulamanın perf duser. 
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
    {
        return _dbSet.Where(expression); //AsQueryable dememe gerek yok cunku zaten where geriye AsQueryable doner.
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.AnyAsync(expression);
    }
}