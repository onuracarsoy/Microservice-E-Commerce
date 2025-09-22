using Microsoft.AspNetCore.Mvc;
using Shop.ServiceDistribute.Dtos.OrderDtos.AddressDtos;
using Shop.ServiceDistribute.Services.Abstract;
using Shop.ServiceDistribute.Services.OrderServices.AddressServices;
using Shop.ServiceDistribute.StaticModels;
using Shop.ServiceDistribute.StaticServices.SelectedAddressServices;

namespace Shop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;
        private readonly ISelectedAddressStaticService _selectedAddressStaticService;

        public OrderController(IAddressService addressService, IUserService userService, ISelectedAddressStaticService selectedAddressStaticService)
        {
            _addressService = addressService;
            _userService = userService;
            _selectedAddressStaticService = selectedAddressStaticService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUserInfo();
            var addresses = await _addressService.GetByUserIdAddressAsync(user.ID);
            return View(addresses);
        }
        [HttpPost]
        public async Task<IActionResult> Index(int addressId)
        {
            var selectedAddress = new SelectedAddressViewModel()
            {
                AddressID = addressId,
            };

            _selectedAddressStaticService.AddSelectedAddress(selectedAddress);

            return RedirectToAction("Index", "Payment");
        }


        [HttpGet]
        public IActionResult AddAddressInTheOrder()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAddressInTheOrder(CreateAddressDto createAddressDto)
        {
            var user = await _userService.GetUserInfo();
            createAddressDto.UserID = user.ID;
            await _addressService.CreateAddressAsync(createAddressDto);
            return View();
        }
    }
}
