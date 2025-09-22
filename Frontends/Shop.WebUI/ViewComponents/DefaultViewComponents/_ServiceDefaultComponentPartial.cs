using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ServiceDistribute.Services.CatalogServices.FeatureServiceServices;

namespace Shop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _ServiceDefaultComponentPartial : ViewComponent
    {
        private readonly IFeautreServiceService _feautreServiceService;

        public _ServiceDefaultComponentPartial(IFeautreServiceService feautreServiceService)
        {
            _feautreServiceService = feautreServiceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           var values =  await _feautreServiceService.GetAllFeatureServiceAsync();
            return View(values);
        }
    }
}
