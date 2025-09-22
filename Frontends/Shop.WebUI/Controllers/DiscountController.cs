using Microsoft.AspNetCore.Mvc;
using Shop.ServiceDistribute.Services.BasketServices;
using Shop.ServiceDistribute.Services.DiscountServices.CouponServices;

namespace Shop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly ICouponService _couponService;
        private readonly IBasketService _basketService;

        public DiscountController(ICouponService couponService, IBasketService basketService)
        {
            _couponService = couponService;
            _basketService = basketService;
        }
        [HttpGet]
        public PartialViewResult ConfirmCouponCode()
        {
           
            return PartialView();
        }

    }
}
