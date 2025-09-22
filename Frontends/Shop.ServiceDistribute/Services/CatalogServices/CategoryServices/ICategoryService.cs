

using Shop.ServiceDistribute.Dtos.CatalogDtos.CategoryDtos;

namespace Shop.ServiceDistribute.Services.CatalogServices.CategoryServices
{
	public interface ICategoryService
	{
		Task<List<ResultCategoryDto>> GetAllCategoryAsync();
		Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
		Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
		Task DeleteCategoryAsync(string id);
		Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
		Task<UpdateCategoryDto> GetByIdCategoryForUpdateAsync(string id);
	}
}
