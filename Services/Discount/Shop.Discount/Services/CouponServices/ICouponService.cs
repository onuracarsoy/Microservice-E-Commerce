using Shop.Discount.Dtos.CouponDtos;

namespace Shop.Discount.Services.CouponServices
{
    public interface ICouponService
    {
        Task<List<ResultCouponDto>> GetAllCouponAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int id);
        Task<GetByIdCouponDto> GetByIdCouponAsync(int id);
        Task<GetCouponCodeDetailByCode> GetCouponCodeDetailByCodeAsync(string code);
    }
}
