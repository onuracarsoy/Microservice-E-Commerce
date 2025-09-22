using Shop.ServiceDistribute.Dtos.CargoDtos.CargoCompanyDtos;
using Shop.ServiceDistribute.Dtos.CargoDtos.CargoCustomer;
using Shop.ServiceDistribute.Dtos.CargoDtos.CargoCustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<int> CreateCargoCustomerAsync(CreateCargoCustomerDto createCargoCustomerDto);
        Task UpdateCargoCustomerAsync(UpdateCargoCustomerDto updateCargoCustomerDto);
        Task<GetByIdCargoCustomerDto> GetByIdCargoCustomerAsync(int id);
    }
}
