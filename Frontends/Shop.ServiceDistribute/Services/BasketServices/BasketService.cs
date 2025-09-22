using Shop.ServiceDistribute.Dtos;
using Shop.ServiceDistribute.Dtos.BasketDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddBasketItemAsync(BasketItemDto basketItemDto)
        {
            var values = await GetBasketAsync();
            if (values is not null)
            {
                var existingItem = values.BasketItems.FirstOrDefault(x => x.ProductID == basketItemDto.ProductID);
                if (existingItem is not null)
                {
                    existingItem.Quantity += basketItemDto.Quantity;
                }
                else
                {
                    values.BasketItems.Add(basketItemDto);
                }
            }
            else
            {
                values = new BasketTotalDto
                {
                    BasketItems = new List<BasketItemDto> { basketItemDto }
                };
            }

            await SaveBasketAsync(values);
        }

        public async Task DeleteBasketAsync(string userId)
        {
            await _httpClient.DeleteAsync($"baskets?id={userId}");
        }

        public async Task<BasketTotalDto> GetBasketAsync()
        {
            var responseMessage = await _httpClient.GetAsync("baskets");
            var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
            return values;   
        }

        public async Task<bool> RemoveBasketItemAsync(string productID)
        {
            var values = await GetBasketAsync();
            var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductID == productID);
            var result = values.BasketItems.Remove(deletedItem);
            await SaveBasketAsync(values);
            return true;
            
        }

        public async Task SaveBasketAsync(BasketTotalDto basketTotalDto)
        {
            await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
        }
    }
}
