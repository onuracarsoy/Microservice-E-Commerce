using Microsoft.AspNetCore.Mvc;
using Shop.ServiceDistribute.Services.BasketServices;

namespace Shop.WebUI.ViewComponents.ShoppingCardViewComponents
{
    public class _ShoppingCartProductListComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _ShoppingCartProductListComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basketTotal = await _basketService.GetBasketAsync();
            var basketItems = basketTotal.BasketItems;
            return View(basketItems);
        }
    }
}
