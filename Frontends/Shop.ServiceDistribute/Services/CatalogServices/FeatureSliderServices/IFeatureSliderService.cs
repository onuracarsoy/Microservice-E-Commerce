using Shop.ServiceDistribute.Dtos.CatalogDtos.FeatureSliderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.CatalogServices.SliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task DeleteFeatureSliderAsync(string id);
        Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id);
        Task FeatureSliderChangeToStatusAsync(string id);
        Task<UpdateFeatureSliderDto> GetByIdFeatureSliderForUpdateAsync(string id);

    }
}
