using Shop.ServiceDistribute.Dtos.OrderDtos.OrderingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.OrderServices.OrderingServices
{
    public interface IOrderingService
    {
        Task<List<ResultOrderingDto>> GetAllOrderingAsync();
        Task<int> CreateOrderingAsync(CreateOrderingDto createOrderingDto);
        Task UpdateOrderingAsync(UpdateOrderingDto updateOrderingDto);
        Task DeleteOrderingAsync(int id);
        Task<GetByIdOrderingDto> GetByIdOrderingAsync(int id);
        Task<List<GetByUserIdOrderingDto>> GetByUserIdOrderingAsync(string id);
        Task<UpdateOrderingDto> GetByIdOrderingForUpdateAsync(int id);
    }
}
