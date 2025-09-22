using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ServiceDistribute.Services.CatalogServices.ProductImageServices;

namespace Shop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {
        private readonly IProductImageService _productImageService;

        public _ProductDetailImageSliderComponentPartial(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string ProductID)
        {

            var value = await _productImageService.GetByProductIDProductImageAsync(ProductID);
            return View(value);

        }
    }
}
