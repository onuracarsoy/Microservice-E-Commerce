using Shop.ServiceDistribute.Dtos.CargoDtos.CargoCompanyDtos;
using Shop.ServiceDistribute.Dtos.CargoDtos.CargoCustomer;
using Shop.ServiceDistribute.Dtos.CargoDtos.CargoCustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.CargoServices.CargoCustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;

        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async  Task<int> CreateCargoCustomerAsync(CreateCargoCustomerDto createCargoCustomerDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateCargoCustomerDto>("cargoCustomers", createCargoCustomerDto);
            responseMessage.EnsureSuccessStatusCode();


            var cargoCustomerId = await responseMessage.Content.ReadFromJsonAsync<int>();

            return cargoCustomerId;

        }

        public async Task UpdateCargoCustomerAsync(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCargoCustomerDto>("cargoCustomers", updateCargoCustomerDto);

        }

        public async Task<GetByIdCargoCustomerDto> GetByIdCargoCustomerAsync(int id)
        {

            var responseMessage = await _httpClient.GetAsync($"cargoCustomers/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCargoCustomerDto>();
            return value;
        }
    }
}
