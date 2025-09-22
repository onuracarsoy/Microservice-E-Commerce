using Microsoft.AspNetCore.Mvc;

namespace Shop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/Message")]
    public class MessageController : Controller
    {
        public IActionResult Chat()
        {
            return View();
        }
    }
}
