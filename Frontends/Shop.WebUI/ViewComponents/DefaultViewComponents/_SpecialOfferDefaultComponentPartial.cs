using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ServiceDistribute.Services.CatalogServices.SpecialOfferServices;

namespace Shop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpecialOfferDefaultComponentPartial : ViewComponent
    {
        private readonly ISpecialOfferService _specialOfferService;

        public _SpecialOfferDefaultComponentPartial(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }
    }
}
