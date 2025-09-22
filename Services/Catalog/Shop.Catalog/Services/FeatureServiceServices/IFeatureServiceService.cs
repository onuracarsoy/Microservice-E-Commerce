using Shop.Catalog.Dtos.FeatureServiceDtos;

namespace Shop.Catalog.Services.FeatureServices
{
    public interface IFeatureServiceService
    {
        Task<List<ResultFeatureServiceDto>> GetAllFeatureServiceAsync();
        Task CreateFeatureServiceAsync(CreateFeatureServiceDto createFeatureServiceDto);
        Task UpdateFeatureServiceAsync(UpdateFeatureServiceDto updateFeatureServiceDto);
        Task DeleteFeatureServiceAsync(string id);
        Task<GetByIdFeatureServiceDto> GetByIdFeatureServiceAsync(string id);
    }
}
