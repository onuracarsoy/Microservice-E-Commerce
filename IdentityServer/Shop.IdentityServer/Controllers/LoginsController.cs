using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.IdentityServer.Dtos;
using Shop.IdentityServer.Models;
using Shop.IdentityServer.Tools;
using System.Threading.Tasks;

namespace Shop.IdentityServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginsController : ControllerBase
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _userManager;

        public LoginsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
		public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
		{
			
			var result = await _signInManager.PasswordSignInAsync(userLoginDto.Email, userLoginDto.Password,false,false);
			var user = await _userManager.FindByNameAsync(userLoginDto.Email);
			if (result.Succeeded)
			{
				GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
				model.Username = userLoginDto.Email;
				model.Id = user.Id;
				var token = JwtTokenGenerator.GenerateToken(model);

				return Ok(token);
			}
			return BadRequest(result);
		}
	}
}
