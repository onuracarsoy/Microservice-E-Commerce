using Shop.ServiceDistribute.Dtos.CatalogDtos.SpecialOfferDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.CatalogServices.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
        Task DeleteSpecialOfferAsync(string id);
        Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id);
        Task SpecialOfferChangeToStatusAsync(string id);
        Task<UpdateSpecialOfferDto> GetByIdSpecialOfferForUpdateAsync(string id);
    }
}
