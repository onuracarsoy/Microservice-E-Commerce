
using Shop.ServiceDistribute.Dtos.CargoDtos.CargoDetailDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.CargoServices.CargoDetailServices
{
    public interface ICargoDetailService
    {
        Task<int> CreateCargoDetailAsync(CreateCargoDetailDto createCargoDetailDto);
        Task UpdateCargoDetailAsync(UpdateCargoDetailDto updateCargoDetailDto);
        Task DeleteCargoDetailAsync(int id);
        Task<GetByIdCargoDetailDto> GetByIdCargoDetailAsync(int? id);
        Task<UpdateCargoDetailDto> GetByIdCargoDetailForUpdateAsync(int id);
    }
}

