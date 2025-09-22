using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ServiceDistribute.Services.CatalogServices.ProductDetailServices;

namespace Shop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailInformationComponentPartial : ViewComponent
    {

        private readonly IProductDetailService _productDetailService;

        public _ProductDetailInformationComponentPartial(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string ProductID)
        {
            var value = await _productDetailService.GetByProductIDProductDetailAsync(ProductID);
            return View(value);

        }
    }
}
