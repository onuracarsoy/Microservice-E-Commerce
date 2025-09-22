using Newtonsoft.Json;
using Shop.ServiceDistribute.Dtos.CatalogDtos.FeatureServiceDtos;
using Shop.ServiceDistribute.Services.CatalogServices.FeatureServiceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.CatalogServices.FeatureServiceServices
{
    public class FeatureServiceService : IFeautreServiceService
    {
        private readonly HttpClient _httpClient;

        public FeatureServiceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateFeatureServiceAsync(CreateFeatureServiceDto createFeatureServiceDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureServiceDto>("featureservices", createFeatureServiceDto);
        }

        public async Task DeleteFeatureServiceAsync(string id)
        {
            await _httpClient.DeleteAsync($"featureservices?id={id}");

        }

        public async Task<List<ResultFeatureServiceDto>> GetAllFeatureServiceAsync()
        {
            var responseMessage = await _httpClient.GetAsync("featureservices");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultFeatureServiceDto>>();

            return values;
        }

        public async Task<GetByIdFeatureServiceDto> GetByIdFeatureServiceAsync(string id)
        {

            var responseMessage = await _httpClient.GetAsync($"featureservices/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdFeatureServiceDto>();
            return value;
        }

        public async Task<UpdateFeatureServiceDto> GetByIdFeatureServiceForUpdateAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"featureservices/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateFeatureServiceDto>();
            return value;
        }


        public async Task UpdateFeatureServiceAsync(UpdateFeatureServiceDto updateFeatureServiceDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureServiceDto>("featureservices", updateFeatureServiceDto);

        }
    }
}
