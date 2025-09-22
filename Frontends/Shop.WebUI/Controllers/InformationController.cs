using Microsoft.AspNetCore.Mvc;

namespace Shop.WebUI.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
