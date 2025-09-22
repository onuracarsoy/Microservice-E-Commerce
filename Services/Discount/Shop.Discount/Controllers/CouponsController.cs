using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Discount.Dtos.CouponDtos;
using Shop.Discount.Services.CouponServices;

namespace Shop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class CouponsController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponsController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet]
        public async Task<IActionResult> CouponList()
        {
            var values = await _couponService.GetAllCouponAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponById(int id)
        {
            var value = await _couponService.GetByIdCouponAsync(id);
            return Ok(value);
        }
        
        [HttpGet("GetCouponCodeDetailByCode")]
        public async Task<IActionResult> GetCouponCodeDetailByCode(string code)
        {
            var value = await _couponService.GetCouponCodeDetailByCodeAsync(code);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
        {
            await _couponService.CreateCouponAsync(createCouponDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _couponService.DeleteCouponAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            await _couponService.UpdateCouponAsync(updateCouponDto);
            return Ok();
        }
    }
}
