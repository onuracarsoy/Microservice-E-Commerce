using Microsoft.AspNetCore.Mvc;
using Shop.ServiceDistribute.Dtos.IdentityDtos.RegisterDtos;
using Shop.ServiceDistribute.Services.Abstract;

namespace Shop.WebUI.Controllers
{
    public class SignUpController : Controller
    {
        private readonly IIdentityForManagerService _identityService;

        public SignUpController(IIdentityForManagerService identityService)
        {
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterDto userRegisterDto)
        {
            var response = await _identityService.SignUp(userRegisterDto);
            if (response)
            {
                return RedirectToAction("Index", "SignIn");
            }
            return View(response);
        }
    }
}
