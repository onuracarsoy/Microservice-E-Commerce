using Shop.ServiceDistribute.Dtos.CatalogDtos.ProductImageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByProductIDProductImageAsync(string id);
        Task<UpdateProductImageDto> GetByIdProductImageForUpdateAsync(string id);

    }
}
