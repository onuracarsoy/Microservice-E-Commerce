using Shop.ServiceDistribute.Dtos.DiscountDtos.CouponDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.DiscountServices.CouponServices
{
    public interface ICouponService
    {
        Task<GetCouponCodeDetailByCode> GetCouponCodeDetailByCodeAsync(string code);
        Task<List<ResultCouponDto>> GetAllCouponAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task<UpdateCouponDto> GetByIdCouponForUpdateAsync(int id);
        Task DeleteCouponAsync(int id);
        Task<GetByIdCouponDto> GetByIdCouponAsync(int id);
    }
}
