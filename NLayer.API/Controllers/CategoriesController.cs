using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategoryByIdWithProducts(int categoryId)
        {
            return CreateActionResult(await _service.GetCategoryByIdWithProductsAsync(categoryId));
        }
    }
}
   