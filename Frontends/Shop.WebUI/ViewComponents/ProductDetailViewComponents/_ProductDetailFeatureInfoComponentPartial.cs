using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.MSIdentity.Shared;
using Newtonsoft.Json;
using Shop.ServiceDistribute.Services.CatalogServices.ProductServices;

namespace Shop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailFeatureInfoComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductDetailFeatureInfoComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string ProductID)
        {
             var value = await _productService.GetByIdProductAsync(ProductID);
             return View(value);
       
        }
    }
}
