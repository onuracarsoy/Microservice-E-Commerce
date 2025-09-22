using Shop.ServiceDistribute.Dtos.CatalogDtos.ProductDtos;

namespace Shop.ServiceDistribute.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task<List<ResultProductWithCategoryDto>> GetProductWihCategoryByCategoryIDAsync(string CategoryID);
        Task<UpdateProductDto> GetByIdProductForUpdateAsync(string id);
    }
}
