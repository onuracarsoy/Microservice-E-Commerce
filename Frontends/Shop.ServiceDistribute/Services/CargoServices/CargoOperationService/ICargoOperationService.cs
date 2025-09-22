using Shop.ServiceDistribute.Dtos.CargoDtos.CargoOperationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.CargoServices.CargoOperationService
{
    public interface ICargoOperationService
    {

        Task UpdateCargoOperationAsync(UpdateCargoOperationDto updateCargoOperationDto);
        Task DeleteCargoOperationAsync(int id);
        Task<int> CreateCargoOperationAsync(CreateCargoOperationDto createCargoCustomerDto);
        Task<GetByIdCargoOperationDto> GetByIdCargoOperationAsync(int id);
        Task<UpdateCargoOperationDto> GetByIdCargoOperationForUpdateAsync(int id);
    }
}
