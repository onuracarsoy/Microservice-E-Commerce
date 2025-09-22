using Shop.ServiceDistribute.Dtos.CargoDtos.CargoCompanyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.CargoServices.CargoCompanyServices
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly HttpClient _httpClient;

        public CargoCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCargoCompanyDto>("cargoCompanies", createCargoCompanyDto);
        }

        public async Task DeleteCargoCompanyAsync(int id)
        {
            await _httpClient.DeleteAsync($"cargoCompanies?id={id}");

        }

        public async Task<List<ResultCargoCompanyDto>> GetAllCargoCompanyAsync()
        {
            var responseMessage = await _httpClient.GetAsync("cargoCompanies");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCargoCompanyDto>>();

            return values;
        }

        public async Task<GetByIdCargoCompanyDto> GetByIdCargoCompanyAsync(int id)
        {

            var responseMessage = await _httpClient.GetAsync($"cargoCompanies/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCargoCompanyDto>();
            return value;
        }

        public async Task<UpdateCargoCompanyDto> GetByIdCargoCompanyForUpdateAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"cargoCompanies/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateCargoCompanyDto>();
            return value;
        }

        public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCargoCompanyDto>("cargoCompanies", updateCargoCompanyDto);

        }
    }
}
