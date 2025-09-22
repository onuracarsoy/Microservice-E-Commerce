using Shop.ServiceDistribute.Dtos.CatalogDtos.ProductDtos;
using System.Net.Http.Json;

namespace Shop.ServiceDistribute.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {

        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDto>("products", createProductDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync($"products?id={id}");
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var responseMessage = await _httpClient.GetAsync("products");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDto>>();

            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("products/productlistwithcategory");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();

            return values;
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"products/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDto>();
            return value;
        }

        public async  Task<UpdateProductDto> GetByIdProductForUpdateAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"products/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDto>();
            return value;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWihCategoryByCategoryIDAsync(string CategoryID)
        {
            var responseMessage = await _httpClient.GetAsync($"products/ProductListWithCategoryByCategoryID?CategoryID={CategoryID}");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();
            return values;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDto>("products", updateProductDto);

        }
    }
}
