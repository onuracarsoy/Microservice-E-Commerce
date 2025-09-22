using Microsoft.AspNetCore.Mvc;

namespace Shop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListPriceFilterComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
