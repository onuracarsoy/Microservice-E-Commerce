using Shop.ServiceDistribute.Dtos.OrderDtos.OrderingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Shop.ServiceDistribute.Services.OrderServices.OrderingServices
{
    public class OrderingService : IOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> CreateOrderingAsync(CreateOrderingDto createOrderingDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateOrderingDto>("orderings", createOrderingDto);
            responseMessage.EnsureSuccessStatusCode();


            var orderingId = await responseMessage.Content.ReadFromJsonAsync<int>();

            return orderingId;
        }

        public async Task DeleteOrderingAsync(int id)
        {
            await _httpClient.DeleteAsync($"orderings?id={id}");

        }

        public async Task<List<ResultOrderingDto>> GetAllOrderingAsync()
        {
            var responseMessage = await _httpClient.GetAsync("orderings");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultOrderingDto>>();

            return values;
        }

        public async Task<GetByIdOrderingDto> GetByIdOrderingAsync(int id)
        {

            var responseMessage = await _httpClient.GetAsync($"orderings/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdOrderingDto>();
            return value;
        }


        public async Task<UpdateOrderingDto> GetByIdOrderingForUpdateAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"orderings/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateOrderingDto>();
            return value;
        }

        public async Task<List<GetByUserIdOrderingDto>> GetByUserIdOrderingAsync(string userID)
        {
            var responseMessage = await _httpClient.GetAsync($"orderings/OrderingListByUserId?userID={userID}");
            if (responseMessage.StatusCode == HttpStatusCode.NoContent || responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            var value = await responseMessage.Content.ReadFromJsonAsync<List<GetByUserIdOrderingDto>>();
            return value;
        }

        public async Task UpdateOrderingAsync(UpdateOrderingDto updateOrderingDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateOrderingDto>("orderings", updateOrderingDto);

        }
    }
}
