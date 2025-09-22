using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.ServiceDistribute.Dtos.OrderDtos.OrderingDetailDto;
using Shop.ServiceDistribute.Dtos.OrderDtos.OrderingDtos;
using Shop.ServiceDistribute.Services.Abstract;
using Shop.ServiceDistribute.Services.BasketServices;
using Shop.ServiceDistribute.Services.OrderServices.OrderingDetailServices;
using Shop.ServiceDistribute.Services.OrderServices.OrderingServices;
using Shop.ServiceDistribute.StaticServices.OrderSummaryServices;
using Shop.ServiceDistribute.StaticServices.SelectedAddressServices;

namespace Shop.WebUI.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {

        private readonly IUserService _userService;
        private readonly IBasketService _basketService;
        private readonly IOrderingService _orderService;
        private readonly IOrderingDetailService _orderDetailService;
        private readonly ISelectedAddressStaticService _selectedAddressStaticService;
        private readonly IOrderSummaryStaticService _orderSummaryStaticService;

        public PaymentController(IUserService userService, IBasketService basketService, IOrderingService orderService, IOrderingDetailService orderDetailService, ISelectedAddressStaticService selectedAddressStaticService, IOrderSummaryStaticService orderSummaryStaticService)
        {
            _userService = userService;
            _basketService = basketService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _selectedAddressStaticService = selectedAddressStaticService;
            _orderSummaryStaticService = orderSummaryStaticService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> CompleteOrder()
        {
            var orderSummary = _orderSummaryStaticService.GetAllSummaries().FirstOrDefault();

            var user = await _userService.GetUserInfo();
            var basketTotal = await _basketService.GetBasketAsync();
            var basketItems = basketTotal.BasketItems;

            var selectedAddress = _selectedAddressStaticService.GetAllSelectedAddress().FirstOrDefault();
            var orderModel = new CreateOrderingDto()
            {
                OrderDate = DateTime.Now,
                OrderTotalPrice = orderSummary.TotalPrice,
                UserID = user.ID,
                AddressID = selectedAddress.AddressID

            };
            var createdOrderId = await _orderService.CreateOrderingAsync(orderModel);
            foreach (var basketItem in basketItems)
            {
                var orderDetailModel = new CreateOrderingDetailDto()
                {
                    OrderingID = createdOrderId,
                    ProductID = basketItem.ProductID,
                    ProductName = basketItem.ProductName,
                    ProductAmount = basketItem.Quantity,
                    ProductPrice = basketItem.Price,
                    ProductTotalPrice = basketItem.Quantity * basketItem.Price,
                };

                await _orderDetailService.CreateOrderingDetailAsync(orderDetailModel);
            }

            _selectedAddressStaticService.RemoveSelectedAddress(1);
            await _basketService.DeleteBasketAsync(user.ID);


            return RedirectToAction("SuccessPayment");
        }

        [HttpGet]
        public IActionResult SuccessPayment()
        {
            return View();
        }
    }
}
