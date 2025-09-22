
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Shop.SignalR.Services.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CatalogStatisticService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<long> TotalCategoryCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7070/api/Statistics/TotalCategoryCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<long>(jsonData);
            return value;
        }

        public async  Task<long> TotalProductCount()
        {
           var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7070/api/Statistics/TotalProductCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<long>(jsonData);
            return value;
        }
    }
}
