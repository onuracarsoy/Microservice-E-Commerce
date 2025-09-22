using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.ServiceDistribute.Services.Abstract;
using Shop.ServiceDistribute.Services.CargoServices.CargoCompanyServices;
using Shop.ServiceDistribute.Services.CargoServices.CargoCustomerServices;
using Shop.ServiceDistribute.Services.CargoServices.CargoDetailServices;
using Shop.ServiceDistribute.Services.CargoServices.CargoOperationService;
using Shop.ServiceDistribute.Services.OrderServices.OrderingDetailServices;
using Shop.ServiceDistribute.Services.OrderServices.OrderingServices;

namespace Shop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    [Route("User/Order")]
    public class OrderController : Controller
    {
        private readonly IOrderingService _orderingService;
        private readonly IOrderingDetailService _orderingDetailService;
        private readonly IUserService _userService;
        private readonly ICargoCompanyService _cargoCompanyService;
        private readonly ICargoDetailService _cargoDetailService;
        private readonly ICargoOperationService _cargoOperationService;
        private readonly ICargoCustomerService _cargoCustomerService;

        public OrderController(IOrderingService orderingService, IOrderingDetailService orderingDetailService, IUserService userService, ICargoCompanyService cargoCompantyService, ICargoDetailService cargoDetailService, ICargoOperationService cargoOperationService, ICargoCustomerService cargoCustomerService)
        {
            _orderingService = orderingService;
            _orderingDetailService = orderingDetailService;
            _userService = userService;
            _cargoCompanyService = cargoCompantyService;
            _cargoDetailService = cargoDetailService;
            _cargoOperationService = cargoOperationService;
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        [Route("MyOrderingList")]
        public async Task<IActionResult> MyOrderingList()
        {
            var user = await _userService.GetUserInfo();
            var values = await _orderingService.GetByUserIdOrderingAsync(user.ID);
            return View(values);
        }

        [HttpGet]
        [Route("OrderDetail/{orderingID}")]
        public async Task<IActionResult> OrderDetail(int orderingID)
        {
            var values = await _orderingDetailService.GetByOrderingIdOrderListAsync(orderingID);
            var ordering = await _orderingService.GetByIdOrderingAsync(orderingID);
            ViewBag.OrderTotalPrice = ordering.OrderTotalPrice;
            return View(values);
        }

        [HttpGet]
        [Route("CargoDetail/{orderingID}")]
        public async Task<IActionResult> CargoDetail(int orderingID)
        {
            var ordering = await _orderingService.GetByIdOrderingAsync(orderingID);


            if (ordering.CargoDetailID is not null)
            {
                var cargoDetail = await _cargoDetailService.GetByIdCargoDetailAsync(ordering.CargoDetailID);
                var cargoCompany = await _cargoCompanyService.GetByIdCargoCompanyAsync(cargoDetail.CargoCompanyID);
                var cargoCustomer = await _cargoCustomerService.GetByIdCargoCustomerAsync(cargoDetail.CargoCustomerID);
                var cargoOperation = await _cargoOperationService.GetByIdCargoOperationAsync(cargoDetail.CargoOperationID);

                ViewBag.CargoCompanyName = cargoCompany.CargoCompanyName;

                ViewBag.OperationBarcode = cargoOperation.CargoOperationBarcode;
                ViewBag.SenderName = cargoDetail.CargoDetailSenderCustomer;
                ViewBag.ReceiverName = cargoDetail.CargoDetailReceiverCustomer;
                ViewBag.OperationDate = cargoOperation.CargoOperationDate.ToShortDateString();
                ViewBag.OperationGuessDate = cargoOperation.CargoOperationDate.AddDays(4).ToShortDateString();
                ViewBag.ReceiverPhone = cargoCustomer.CargoCustomerPhone;
                ViewBag.ReceiverAddress = cargoCustomer.CargoCustomerAddress + " " + cargoCustomer.CargoCustomerDistrict + "/" + cargoCustomer.CargoCustomerCity;

                ViewBag.StepOne = cargoOperation.CargoStepOne ? "completed" : "";
                ViewBag.StepTwo = cargoOperation.CargoStepTwo ? "completed" : "";
                ViewBag.StepThree = cargoOperation.CargoStepThree ? "completed" : "";
                ViewBag.StepFour = cargoOperation.CargoStepFour ? "completed" : "";
                ViewBag.StepFive = cargoOperation.CargoStepFive ? "completed" : "";
                ViewBag.IsNotShipped = "false";
            }
            else
            {
                ViewBag.IsNotShipped = "true";
            }

            return View();
        }
    }
}
