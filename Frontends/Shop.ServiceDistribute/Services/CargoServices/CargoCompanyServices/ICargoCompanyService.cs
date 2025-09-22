using Shop.ServiceDistribute.Dtos.CargoDtos.CargoCompanyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.CargoServices.CargoCompanyServices
{
    public interface ICargoCompanyService
    {
        Task<List<ResultCargoCompanyDto>> GetAllCargoCompanyAsync();
        Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto);
        Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto);
        Task DeleteCargoCompanyAsync(int id);
        Task<GetByIdCargoCompanyDto> GetByIdCargoCompanyAsync(int id);
        Task<UpdateCargoCompanyDto> GetByIdCargoCompanyForUpdateAsync(int id);
    }
}
