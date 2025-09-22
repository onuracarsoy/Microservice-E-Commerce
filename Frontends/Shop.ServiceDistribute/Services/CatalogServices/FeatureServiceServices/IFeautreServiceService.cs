using Shop.ServiceDistribute.Dtos.CatalogDtos.FeatureServiceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.CatalogServices.FeatureServiceServices
{
    public interface IFeautreServiceService
    {
        Task<List<ResultFeatureServiceDto>> GetAllFeatureServiceAsync();
        Task CreateFeatureServiceAsync(CreateFeatureServiceDto createFeatureServiceDto);
        Task UpdateFeatureServiceAsync(UpdateFeatureServiceDto updateFeatureServiceDto);
        Task DeleteFeatureServiceAsync(string id);
        Task<GetByIdFeatureServiceDto> GetByIdFeatureServiceAsync(string id);
        Task<UpdateFeatureServiceDto> GetByIdFeatureServiceForUpdateAsync(string id);

    }
}
