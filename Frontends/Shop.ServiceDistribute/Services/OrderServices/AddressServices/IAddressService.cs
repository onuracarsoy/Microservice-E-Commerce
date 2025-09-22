using Shop.ServiceDistribute.Dtos.OrderDtos.AddressDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.OrderServices.AddressServices
{
    public interface IAddressService
    {
        Task<List<ResultAddressDto>> GetAllAddressAsync();
        Task CreateAddressAsync(CreateAddressDto createAddressDto);
        Task UpdateAddressAsync(UpdateAddressDto updateAddressDto);
        Task DeleteAddressAsync(int id);
        Task<GetByIdAddressDto> GetByIdAddressAsync(int id);
        Task<List<GetByUserIdAddressDto>> GetByUserIdAddressAsync(string id);
        Task<UpdateAddressDto> GetByIdAddressForUpdateAsync(int id);
    }
}
