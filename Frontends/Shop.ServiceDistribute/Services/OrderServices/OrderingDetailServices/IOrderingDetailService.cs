using Shop.ServiceDistribute.Dtos.OrderDtos.OrderingDetailDto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.OrderServices.OrderingDetailServices
{
    public interface IOrderingDetailService
    {
        Task<List<ResultOrderingDetailDto>> GetAllOrderingDetailAsync();
        Task CreateOrderingDetailAsync(CreateOrderingDetailDto createOrderingDetailDto);
        Task UpdateOrderingDetailAsync(UpdateOrderingDetailDto updateOrderingDetailDto);
        Task DeleteOrderingDetailAsync(int id);
        Task<GetByIdOrderingDetailDto> GetByIdOrderingDetailAsync(int id);
        Task<List<GetByOrderingIdOrderingDetailDto>> GetByOrderingIdOrderListAsync(int orderingID);
        Task<UpdateOrderingDetailDto> GetByIdOrderingDetailForUpdateAsync(int id);
    }
}
