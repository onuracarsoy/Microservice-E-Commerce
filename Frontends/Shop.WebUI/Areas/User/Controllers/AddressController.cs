using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.ServiceDistribute.Dtos.OrderDtos.AddressDtos;
using Shop.ServiceDistribute.Services.Abstract;
using Shop.ServiceDistribute.Services.OrderServices.AddressServices;

namespace Shop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    [Route("User/Address")]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;

        public AddressController(IAddressService addressService, IUserService userService)
        {
            _addressService = addressService;
            _userService = userService;
        }

        [HttpGet]
        [Route("MyAddressList")]
        public async Task<IActionResult> MyAddressList()
        {
            var user = await _userService.GetUserInfo();
            var values = await _addressService.GetByUserIdAddressAsync(user.ID);
            return View(values);
        }

        [HttpGet]
        [Route("UpdateAddress/{id}")]
        public async Task<IActionResult> UpdateAddress(int id)
        {
            var value = await _addressService.GetByIdAddressForUpdateAsync(id);
            return View(value);
        }
        [HttpPost]
        [Route("UpdateAddress/{id}")]
        public async Task<IActionResult> UpdateAddress(UpdateAddressDto updateAddressDto)
        {
            var user = await _userService.GetUserInfo();
            updateAddressDto.UserID = user.ID;
            await _addressService.UpdateAddressAsync(updateAddressDto);
            return RedirectToAction("MyAddressList", "Address", new { area = "User" });

        }

        [HttpGet]
        [Route("AddAddress")]
        public IActionResult AddAddress()
        {

            return View();
        }
        [HttpPost]
        [Route("AddAddress")]
        public async Task<IActionResult> AddAddress(CreateAddressDto createAddressDto)
        {
            var user = await _userService.GetUserInfo();
            createAddressDto.UserID = user.ID;
            await _addressService.CreateAddressAsync(createAddressDto);
            return RedirectToAction("MyAddressList", "Address", new { area = "User" });

        }

        [Route("RemoveAddress/{id}")]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _addressService.DeleteAddressAsync(id);
            return RedirectToAction("MyAddressList", "Address", new { area = "User" });
        }
    }
}
