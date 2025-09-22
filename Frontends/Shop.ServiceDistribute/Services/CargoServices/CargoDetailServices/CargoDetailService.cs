using Shop.ServiceDistribute.Dtos.CargoDtos.CargoCompanyDtos;
using Shop.ServiceDistribute.Dtos.CargoDtos.CargoDetailDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.CargoServices.CargoDetailServices
{
    public class CargoDetailService : ICargoDetailService
    {
        private readonly HttpClient _httpClient;

        public CargoDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> CreateCargoDetailAsync(CreateCargoDetailDto createCargoDetailDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateCargoDetailDto>("cargoDetails", createCargoDetailDto);
            responseMessage.EnsureSuccessStatusCode();


            var cargoDetailId = await responseMessage.Content.ReadFromJsonAsync<int>();

            return cargoDetailId;
        }

        public async Task DeleteCargoDetailAsync(int id)
        {
            await _httpClient.DeleteAsync($"cargoDetails?id={id}");

        }


        public async Task<GetByIdCargoDetailDto> GetByIdCargoDetailAsync(int? id)
        {

            var responseMessage = await _httpClient.GetAsync($"cargoDetails/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCargoDetailDto>();
            return value;
        }

        public async Task<UpdateCargoDetailDto> GetByIdCargoDetailForUpdateAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"cargoDetails/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateCargoDetailDto>();
            return value;
        }

        public async Task UpdateCargoDetailAsync(UpdateCargoDetailDto updateCargoDetailDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCargoDetailDto>("cargoDetails", updateCargoDetailDto);

        }
    }
}
