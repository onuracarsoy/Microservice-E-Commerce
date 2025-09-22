using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.IdentityServer.Dtos;
using Shop.IdentityServer.Models;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace Shop.IdentityServer.Controllers
{
    [Authorize (LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet ("GetUserInfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            var userClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            var user = await _userManager.FindByIdAsync(userClaim.Value);
            return Ok(new
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserName = user.UserName
            });
        }

        [HttpGet("GetByUserIdWithUserInfo")]
        public async Task<IActionResult> GetByUserIdWithUserInfo(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("UserId is required.");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(new
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserName = user.UserName
            });
        }

        [HttpGet("GetAllUserList")]
        public async Task<IActionResult> GetAllUserList()
        {
           
          var users = await _userManager.Users.ToListAsync();
            return Ok(users);
        }

        [HttpPut("UpdateUserInfo")]
        public async Task<IActionResult> UpdateUserInfo([FromBody] UpdateUserDto updateUserDto)
        {


            var userClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            var user = await _userManager.FindByIdAsync(userClaim.Value);

            if (user == null)
                return NotFound("User not found.");

            user.Name = updateUserDto.Name;
            user.Surname = updateUserDto.Surname;
            user.Email = updateUserDto.Email;
            user.UserName = updateUserDto.Email;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new
            {
                Message = "User information updated successfully.",
                User = new
                {
                    user.Id,
                    user.Name,
                    user.Surname,
                    user.Email,
                    user.UserName
                }
            });
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
    
            var userClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            var user = await _userManager.FindByIdAsync(userClaim.Value);

            if (user == null)
                return NotFound("User not found.");

            var result = await _userManager.ChangePasswordAsync(user, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new
            {
                Message = "Password changed successfully."
            });
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] string userId)
        {
  
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound("User not found.");


            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new
            {
                Message = "User deleted successfully."
            });
        }
    }
}
