using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.ServiceDistribute.Dtos.IdentityDtos.UserDtos;
using Shop.ServiceDistribute.Model;
using Shop.ServiceDistribute.Services.Abstract;

namespace Shop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    [Route("User/Profile")]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("MyProfile")]
        public async  Task<IActionResult> MyProfile()
        {
            var model = await _userService.GetUserForUpdateInfo();
            return View(model);
        }
        [HttpPost]
        [Route("MyProfile")]
        public async Task<IActionResult> MyProfile(UpdateUserDto model)
        {
           var response =  await _userService.UpdateUserInfo(model);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.UpdateStatus = "true";
                return View();
            }
            else
            {
                ViewBag.UpdateStatus = "false";
                return View();
            }
          
        }

     
    }
}
