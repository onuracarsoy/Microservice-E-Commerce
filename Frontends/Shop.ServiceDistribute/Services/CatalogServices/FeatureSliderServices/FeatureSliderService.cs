using Newtonsoft.Json;
using Shop.ServiceDistribute.Dtos.CatalogDtos.FeatureSliderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.CatalogServices.SliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly HttpClient _httpClient;

        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("featuresliders", createFeatureSliderDto);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _httpClient.DeleteAsync($"featuresliders?id={id}");

        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var responseMessage = await _httpClient.GetAsync("featuresliders");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultFeatureSliderDto>>();

            return values;
        }

        public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {

            var responseMessage = await _httpClient.GetAsync($"featuresliders/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdFeatureSliderDto>();
            return value;
        }

        public async Task<UpdateFeatureSliderDto> GetByIdFeatureSliderForUpdateAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"featuresliders/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateFeatureSliderDto>();
            return value;
        }

        public async Task FeatureSliderChangeToStatusAsync(string id)
        {
            var content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");


            await _httpClient.PutAsync($"featuresliders/FeatureSliderChangeToStatus?id={id}", content);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDto>("featuresliders", updateFeatureSliderDto);

        }
    }
}
