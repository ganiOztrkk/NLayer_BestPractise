using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository 
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Category> GetCategoryByIdWithProductsAsync(int categoryId)
    {
        return (await _context.Categories
            .Include(x => x.Products)
            .Where(x => x.Id == categoryId)
            .SingleOrDefaultAsync())!;
        
        //singleordefault - firstordefault : first eger kosulu saglayan 4-5 data varsa bana ilk buldugunu doner. single ise eger kosunu saglayan 1den fazla data varsa geriye hata döner. eger data 1den fazlaysa first geriye exception donmez single doner.
    }
}