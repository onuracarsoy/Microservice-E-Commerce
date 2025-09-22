
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Shop.ServiceDistribute.Dtos.OrderDtos.OrderingDetailDto;
using Shop.ServiceDistribute.Dtos.OrderDtos.OrderingDtos;

namespace Shop.ServiceDistribute.Services.OrderServices.OrderingDetailServices
{
    public class OrderingDetailService : IOrderingDetailService
    {
        private readonly HttpClient _httpClient;

        public OrderingDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOrderingDetailAsync(CreateOrderingDetailDto createOrderingDetailDto)
        {
            await _httpClient.PostAsJsonAsync<CreateOrderingDetailDto>("orderDetails", createOrderingDetailDto);
        }

        public async Task DeleteOrderingDetailAsync(int id)
        {
            await _httpClient.DeleteAsync($"orderDetails?id={id}");

        }

        public async Task<List<ResultOrderingDetailDto>> GetAllOrderingDetailAsync()
        {
            var responseMessage = await _httpClient.GetAsync("orderDetails");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultOrderingDetailDto>>();

            return values;
        }

        public async Task<GetByIdOrderingDetailDto> GetByIdOrderingDetailAsync(int id)
        {

            var responseMessage = await _httpClient.GetAsync($"orderDetails/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdOrderingDetailDto>();
            return value;
        }


        public async Task<UpdateOrderingDetailDto> GetByIdOrderingDetailForUpdateAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"orderDetails/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateOrderingDetailDto>();
            return value;
        }

        public async Task<List<GetByOrderingIdOrderingDetailDto>> GetByOrderingIdOrderListAsync(int orderingID)
        {
            var responseMessage = await _httpClient.GetAsync($"orderDetails/OrderDetailListByOrderingId?orderingID={orderingID}");
            if (responseMessage.StatusCode == HttpStatusCode.NoContent || responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            var value = await responseMessage.Content.ReadFromJsonAsync<List<GetByOrderingIdOrderingDetailDto>>();
            return value;
        }

        public async Task UpdateOrderingDetailAsync(UpdateOrderingDetailDto updateOrderingDetailDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateOrderingDetailDto>("orderDetails", updateOrderingDetailDto);

        }

    }
}
