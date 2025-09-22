using Shop.ServiceDistribute.Dtos.OrderDtos.AddressDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.OrderServices.AddressServices
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;

        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAddressAsync(CreateAddressDto createAddressDto)
        {
            await _httpClient.PostAsJsonAsync<CreateAddressDto>("addresses", createAddressDto);
        }

        public async Task DeleteAddressAsync(int id)
        {
            await _httpClient.DeleteAsync($"addresses?id={id}");

        }

        public async Task<List<ResultAddressDto>> GetAllAddressAsync()
        {
            var responseMessage = await _httpClient.GetAsync("addresses");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultAddressDto>>();

            return values;
        }

        public async Task<GetByIdAddressDto> GetByIdAddressAsync(int id)
        {

            var responseMessage = await _httpClient.GetAsync($"addresses/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdAddressDto>();
            return value;
        }


        public async Task<UpdateAddressDto> GetByIdAddressForUpdateAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"addresses/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateAddressDto>();
            return value;
        }

        public async Task<List<GetByUserIdAddressDto>> GetByUserIdAddressAsync(string userID)
        {
            var responseMessage = await _httpClient.GetAsync($"addresses/AddressListByUserId?userID={userID}");
            if (responseMessage.StatusCode == HttpStatusCode.NoContent || responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            var value = await responseMessage.Content.ReadFromJsonAsync<List<GetByUserIdAddressDto>>();
            return value;
        }

        public async Task UpdateAddressAsync(UpdateAddressDto updateAddressDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateAddressDto>("addresses", updateAddressDto);

        }
    }
}
