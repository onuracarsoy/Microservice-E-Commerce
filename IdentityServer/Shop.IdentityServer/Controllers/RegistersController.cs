using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.IdentityServer.Dtos;
using Shop.IdentityServer.Models;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace Shop.IdentityServer.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            var value = new ApplicationUser()
            {
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname,
                UserName=userRegisterDto.Email

            };

            var result = await _userManager.CreateAsync(value, userRegisterDto.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest(result);
        }
    }
}
