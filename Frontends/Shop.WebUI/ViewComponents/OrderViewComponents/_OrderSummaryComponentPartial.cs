using Microsoft.AspNetCore.Mvc;
using Shop.ServiceDistribute.Services.BasketServices;
using Shop.ServiceDistribute.Services.DiscountServices.CouponServices;
using Shop.ServiceDistribute.StaticServices.OrderSummaryServices;
using Shop.WebUI.Models;

namespace Shop.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderSummaryComponentPartial  : ViewComponent
    {
        private readonly IBasketService _basketService;
        private readonly ICouponService _couponService;
        private readonly IOrderSummaryStaticService _orderSummaryStaticService;

        public _OrderSummaryComponentPartial(IBasketService basketService, ICouponService couponService, IOrderSummaryStaticService orderSummaryStaticService)
        {
            _basketService = basketService;
            _couponService = couponService;
            _orderSummaryStaticService = orderSummaryStaticService;
        }
      

        public async Task<IViewComponentResult> InvokeAsync()
        {
          
            var orderSummary = _orderSummaryStaticService.GetAllSummaries().FirstOrDefault();
            ViewBag.SubTotalPrice = orderSummary.SubTotalPrice;
            ViewBag.TotalPrice = orderSummary.TotalPrice;
            ViewBag.KDVAmount = orderSummary.KDVAmount;
            ViewBag.KDVWithTotalPrice = orderSummary.KDVWithTotalPrice;
            ViewBag.DiscountAmount = orderSummary.DiscountAmount;
            ViewBag.CouponConfirmStatus = orderSummary.CouponConfirmStatus;
           


            var basketTotal = await _basketService.GetBasketAsync();
            var basketItems = basketTotal.BasketItems;
            return View(basketItems);
        }
    }
}
