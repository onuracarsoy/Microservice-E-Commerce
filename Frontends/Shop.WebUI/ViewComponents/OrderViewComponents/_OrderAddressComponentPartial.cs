using Microsoft.AspNetCore.Mvc;
using Shop.ServiceDistribute.Services.Abstract;
using Shop.ServiceDistribute.Services.OrderServices.AddressServices;

namespace Shop.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderAddressComponentPartial : ViewComponent
    {
        private readonly IUserService _userService;
        private readonly IAddressService _addressService;

        public _OrderAddressComponentPartial(IUserService userService, IAddressService addressService)
        {
            _userService = userService;
            _addressService = addressService;
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();
            var addresses = await _addressService.GetByUserIdAddressAsync(user.ID);
            return View(addresses);
        }
    }
}
