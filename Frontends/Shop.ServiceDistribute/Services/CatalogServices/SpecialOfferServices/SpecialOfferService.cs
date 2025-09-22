using Newtonsoft.Json;
using Shop.ServiceDistribute.Dtos.CatalogDtos.SpecialOfferDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("specialoffers", createSpecialOfferDto);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _httpClient.DeleteAsync($"specialoffers?id={id}");

        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var responseMessage = await _httpClient.GetAsync("specialoffers");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSpecialOfferDto>>();

            return values;
        }

        public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {

            var responseMessage = await _httpClient.GetAsync($"specialoffers/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdSpecialOfferDto>();
            return value;
        }

        public async Task<UpdateSpecialOfferDto> GetByIdSpecialOfferForUpdateAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"specialoffers/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateSpecialOfferDto>();
            return value;
        }

        public async Task SpecialOfferChangeToStatusAsync(string id)
        {
            var content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");


            await _httpClient.PutAsync($"specialoffers/SpecialOfferChangeToStatus?id={id}", content);
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("specialoffers", updateSpecialOfferDto);

        }
    }
}
