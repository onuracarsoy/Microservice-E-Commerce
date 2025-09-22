using Shop.ServiceDistribute.Dtos.CargoDtos.CargoOperationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.CargoServices.CargoOperationService
{
    public class CargoOperationService : ICargoOperationService
    {
        private readonly HttpClient _httpClient;

        public CargoOperationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> CreateCargoOperationAsync(CreateCargoOperationDto createCargoOperationDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateCargoOperationDto>("cargoOperations", createCargoOperationDto);
            responseMessage.EnsureSuccessStatusCode();


            var cargoOperationId = await responseMessage.Content.ReadFromJsonAsync<int>();

            return cargoOperationId;

        }

  

        public async Task DeleteCargoOperationAsync(int id)
        {
            await _httpClient.DeleteAsync($"cargoOperations?id={id}");

        }

        public async Task<GetByIdCargoOperationDto> GetByIdCargoOperationAsync(int id)
        {

            var responseMessage = await _httpClient.GetAsync($"cargoOperations/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCargoOperationDto>();
            return value;
        }

        public async Task<UpdateCargoOperationDto> GetByIdCargoOperationForUpdateAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"cargoOperations/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateCargoOperationDto>();
            return value;
        }

        public async Task UpdateCargoOperationAsync(UpdateCargoOperationDto updateCargoOperationDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCargoOperationDto>("cargoOperations", updateCargoOperationDto);

        }
    }
}
