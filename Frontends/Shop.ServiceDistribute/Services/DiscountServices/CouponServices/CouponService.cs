using Shop.ServiceDistribute.Dtos.DiscountDtos.CouponDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.DiscountServices.CouponServices
{
    public class CouponService : ICouponService
    {
        private readonly HttpClient _httpClient;

        public CouponService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCouponDto>("coupons", createCouponDto);
        }

        public async Task DeleteCouponAsync(int id)
        {
            await _httpClient.DeleteAsync($"coupons?id={id}");

        }

        public async Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            var responseMessage = await _httpClient.GetAsync("coupons");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCouponDto>>();

            return values;
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {

            var responseMessage = await _httpClient.GetAsync($"coupons/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCouponDto>();
            return value;
        }

        public async Task<UpdateCouponDto> GetByIdCouponForUpdateAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"coupons/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateCouponDto>();
            return value;
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCouponDto>("coupons", updateCouponDto);

        }
        public async Task<GetCouponCodeDetailByCode> GetCouponCodeDetailByCodeAsync(string code)
        {
            if (code is not null)
            {
                var responseMessage = await _httpClient.GetAsync($"coupons/GetCouponCodeDetailByCode?code={code}");
                if (responseMessage.StatusCode == HttpStatusCode.NoContent || responseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                var value = await responseMessage.Content.ReadFromJsonAsync<GetCouponCodeDetailByCode>();
                return value;
            }
            return null;
        }

   

      
    }
}
