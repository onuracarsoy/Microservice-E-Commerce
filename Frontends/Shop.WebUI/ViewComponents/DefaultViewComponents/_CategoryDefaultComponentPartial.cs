using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ServiceDistribute.Services.CatalogServices.CategoryServices;

namespace Shop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategoryDefaultComponentPartial : ViewComponent
    {
     private readonly ICategoryService _categoryService;

        public _CategoryDefaultComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
