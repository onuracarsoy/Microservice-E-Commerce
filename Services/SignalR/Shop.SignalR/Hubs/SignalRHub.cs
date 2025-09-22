using Microsoft.AspNetCore.SignalR;
using Shop.SignalR.Services.CatalogStatisticServices;
using System.Runtime.CompilerServices;

namespace Shop.SignalR.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICatalogStatisticService _catalogStatisticService;

        public SignalRHub(ICatalogStatisticService catalogStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
        }


        public async Task SendTotalProductCount()
        {
            var value = await _catalogStatisticService.TotalProductCount();
            await Clients.All.SendAsync("ReceiveTotalProductCount", value);

        }
        
        public async Task SendTotalCategoryCount()
        {
            var value = await _catalogStatisticService.TotalCategoryCount();
            await Clients.All.SendAsync("ReceiveTotalCategoryCount", value);

        }
    }
}
