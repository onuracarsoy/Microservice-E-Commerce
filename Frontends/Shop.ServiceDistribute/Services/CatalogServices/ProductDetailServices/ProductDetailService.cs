using Shop.ServiceDistribute.Dtos.CatalogDtos.ProductDetailDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDetailDto>("productdetails", createProductDetailDto);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _httpClient.DeleteAsync($"productdetails?id={id}");

        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productdetails");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDetailDto>>();

            return values;
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {

            var responseMessage = await _httpClient.GetAsync($"productdetails/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();
            return value;
        }

        public async Task<UpdateProductDetailDto> GetByIdProductDetailForUpdateAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"productdetails/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDetailDto>();
            return value;
        }

        public async Task<GetByIdProductDetailDto> GetByProductIDProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"ProductDetails/GetByProductIDProductDetail?id={id}");
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();
                return value;
            }
            return null;

        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDetailDto>("productdetails", updateProductDetailDto);

        }
    }
}
