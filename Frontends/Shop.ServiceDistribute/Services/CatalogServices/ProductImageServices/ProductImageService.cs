using Newtonsoft.Json;
using Shop.ServiceDistribute.Dtos.CatalogDtos.ProductImageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {

        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductImageDto>("productimages", createProductImageDto);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync($"productimages?id={id}");

        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productimages");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductImageDto>>();

            return values;
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {

            var responseMessage = await _httpClient.GetAsync($"productimages/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
            return value;
        }

        public async Task<UpdateProductImageDto> GetByIdProductImageForUpdateAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"productimages/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateProductImageDto>();
            return value;
        }

        public async Task<GetByIdProductImageDto> GetByProductIDProductImageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"ProductImages/GetByProductIDProductImage?id={id}");
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
                return value;
            }
            return null;

        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductImageDto>("productimages", updateProductImageDto);

        }
    }
}
