using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Shop.ServiceDistribute.Dtos.IdentityDtos.LoginDtos;
using Shop.ServiceDistribute.Services.Concrete;

namespace Shop.WebUI.Controllers
{
    public class SignInController : Controller
    {
        private readonly IdentityForManagerService _identityService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SignInController(IdentityForManagerService identityService, IHttpContextAccessor httpContextAccessor)
        {
            _identityService = identityService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            #region Token Kontrolü
            //Giriş Yapılmışsa Token İle Default/Index yönlendir
            var accessToken = await _httpContextAccessor.HttpContext?.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            if (!string.IsNullOrEmpty(accessToken))
            {
                return RedirectToAction("Index", "Default");
            }
            #endregion

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto userLoginDto)
        {
           

            var result = await _identityService.SignIn(userLoginDto);
            if (result)
            {
                ViewBag.Error = "false";
                return RedirectToAction("Index", "Default");
            }
            else
            {
                ViewBag.Error = "true";
            }
            return View();

        }



        public async Task<IActionResult> Logout()
        {
            // Kullanıcı oturumunu sonlandır
            await HttpContext.SignOutAsync("Cookies"); // Çerez tabanlı oturum sonlandırma

            // Ana sayfaya veya giriş sayfasına yönlendir
            return RedirectToAction("Index", "Login");
        }
    }
}
