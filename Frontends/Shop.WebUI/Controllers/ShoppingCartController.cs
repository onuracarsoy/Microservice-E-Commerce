using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Shop.ServiceDistribute.Dtos;
using Shop.ServiceDistribute.Dtos.BasketDtos;
using Shop.ServiceDistribute.Dtos.DiscountDtos.CouponDtos;
using Shop.ServiceDistribute.Models;
using Shop.ServiceDistribute.Services.Abstract;
using Shop.ServiceDistribute.Services.BasketServices;
using Shop.ServiceDistribute.Services.CatalogServices.ProductServices;
using Shop.ServiceDistribute.Services.DiscountServices.CouponServices;
using Shop.ServiceDistribute.Services.OrderServices.AddressServices;
using Shop.ServiceDistribute.StaticServices.OrderSummaryServices;
using Shop.WebUI.Models;
using Shop.WebUI.ViewComponents.OrderViewComponents;

namespace Shop.WebUI.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        private readonly ICouponService _couponService;
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;
        private readonly IOrderSummaryStaticService _orderSummaryStaticService;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShoppingCartController(IProductService productService, IBasketService basketService, ICouponService couponService, IAddressService addressService, IUserService userService, IOrderSummaryStaticService orderSummaryStaticService, IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _basketService = basketService;
            _couponService = couponService;
            _addressService = addressService;
            _userService = userService;
            _orderSummaryStaticService = orderSummaryStaticService;
            _httpContextAccessor = httpContextAccessor;
        }

        #region Hesaplama Metotları
        public decimal KdvCalculation(decimal totalPrice)
        {
            const decimal kdvRate = 10m / 100m;

            // KDV tutarını hesapla (toplam fiyattan KDV'yi ayır)
            decimal kdvAmount = totalPrice - (totalPrice / (1 + kdvRate));

            // ViewBag'e KDV tutarını ekle
            ViewBag.KDVAmount = Math.Round(kdvAmount, 2);

            // KDV Hariç fiyatı döndür
            return Math.Round(totalPrice / (1 + kdvRate), 2);
        }

        public decimal DiscountCalculation(decimal kdvWithTotalPrice, int discountRate)
        {
            decimal totalNewPriceWithDiscount = kdvWithTotalPrice - (kdvWithTotalPrice / 100 * discountRate);
            ViewBag.DiscountAmount = Math.Round((totalNewPriceWithDiscount - kdvWithTotalPrice), 2);
            return Math.Round(totalNewPriceWithDiscount, 2);
        }

        public async Task PriceCalculation()
        {
            var basketValue = await _basketService.GetBasketAsync();
            ViewBag.SubTotalPrice = basketValue.TotalPrice;
            ViewBag.KDVWithTotalPrice = KdvCalculation(basketValue.TotalPrice) + ViewBag.KDVAmount;
            ViewBag.TotalPrice = ViewBag.KDVWithTotalPrice;
        }
        #endregion

        #region Sipariş Özeti Metotları

        public void SetOrderSummary()
        {
            OrderSummaryViewModel model = new OrderSummaryViewModel()
            {
                SubTotalPrice = ViewBag.SubTotalPrice,
                KDVAmount = ViewBag.KDVAmount,
                KDVWithTotalPrice = ViewBag.KDVWithTotalPrice,
                TotalPrice = ViewBag.TotalPrice,
                DiscountAmount = ViewBag.DiscountAmount,
                CouponConfirmStatus = ViewBag.CouponConfirmStatus
            };
            _orderSummaryStaticService.AddSummary(model);
        }

        public void UpdateOrderSummary()
        {
            OrderSummaryViewModel model = new OrderSummaryViewModel()
            {
                SubTotalPrice = ViewBag.SubTotalPrice,
                KDVAmount = ViewBag.KDVAmount,
                KDVWithTotalPrice = ViewBag.KDVWithTotalPrice,
                TotalPrice = ViewBag.TotalPrice,
                DiscountAmount = ViewBag.DiscountAmount,
                CouponConfirmStatus = ViewBag.CouponConfirmStatus
            };
            _orderSummaryStaticService.UpdateSummary(model);
        }

        #endregion

        #region Adres Varlığına Göre Yönlendirme Metodu

        public async Task SetUrlByAddressStatusInfoAsync()
        {

            var user = await _userService.GetUserInfo();
            var addresses = await _addressService.GetByUserIdAddressAsync(user.ID);
            var basket = await _basketService.GetBasketAsync();
            var basketItems = basket.BasketItems;
            if (addresses is null || addresses.Count == 0)
            {
                ViewBag.AddressRoute = "/Order/AddAddressInTheOrder";
            }
            else if (basketItems is null || basketItems.Count == 0)
            {
                ViewBag.AddressRoute = " ";
            }
            else
            {
                ViewBag.AddressRoute = "/Order/Index";
            }
        }

        #endregion



        [HttpGet]
        public async Task<IActionResult> Index()
        {

            await SetUrlByAddressStatusInfoAsync();

            await PriceCalculation();

            //Kupon kodu yoksa sipariş özetini güncelle
            if (ViewBag.CouponCode is null)
            {
                UpdateOrderSummary();
            }

            SetOrderSummary();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string couponCode)
        {
            ViewBag.CouponCode = couponCode;

            var basketValue = await _basketService.GetBasketAsync();
            var couponValue = await _couponService.GetCouponCodeDetailByCodeAsync(couponCode);

            //Kupon kodu kontrolü
            if (couponValue is not null && couponValue.CouponValidDate >= DateTime.Now)
            {
                ViewBag.CouponConfirmStatus = "true";
                await PriceCalculation();
                ViewBag.TotalPrice = DiscountCalculation(KdvCalculation(basketValue.TotalPrice), couponValue.CouponRate);
                UpdateOrderSummary();
                await SetUrlByAddressStatusInfoAsync();

                return View();
            }
            else
            {
                ViewBag.CouponConfirmStatus = "false";
                await PriceCalculation();
                UpdateOrderSummary();
                await SetUrlByAddressStatusInfoAsync();
                return View();
            }


        }

        [Route("ShoppingCart/AddBasketItem/{productID}")]
        public async Task<IActionResult> AddBasketItem(string productID)
        {

            var value = await _productService.GetByIdProductAsync(productID);

            var item = new BasketItemDto
            {
                ProductID = value.ProductID,
                ProductName = value.ProductName,
                ProductImageUrl = value.ProductImageUrl,
                Price = value.ProductPrice,
                Quantity = 1
            };
            await _basketService.AddBasketItemAsync(item);
            return RedirectToAction("Index");
        }

        [Route("ShoppingCart/RemoveBasketItem/{productID}")]
        public async Task<IActionResult> RemoveBasketItem(string productID)
        {
            await _basketService.RemoveBasketItemAsync(productID);
            return RedirectToAction("Index");
        }
    }
}

