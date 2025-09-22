using Dapper;
using Shop.Discount.Context;
using Shop.Discount.Dtos.CouponDtos;

namespace Shop.Discount.Services.CouponServices
{
    public class CouponService : ICouponService
    {
        private readonly DapperContext _dapperContext;

        public CouponService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons (CouponCode,CouponRate,CouponValidDate,CouponIsActive) Values (@CouponCode,@CouponRate,@CouponValidDate,@CouponIsActive)";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponCode", createCouponDto.CouponCode);
            parameters.Add("@CouponRate", createCouponDto.CouponRate);
            parameters.Add("@CouponValidDate", createCouponDto.CouponValidDate);
            parameters.Add("@CouponIsActive", createCouponDto.CouponIsActive);

            using (var connection = _dapperContext.CreateConnection())
            {
               await connection.ExecuteAsync(query, parameters);
            
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "Delete From Coupons Where CouponID = @CouponID";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponID", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }

        }

        public async Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            string query = "Select CouponID,CouponCode,CouponRate,CouponValidDate,CouponIsActive From Coupons";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
          
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            string query = "Select CouponID,CouponCode,CouponRate,CouponValidDate, CouponIsActive From Coupons Where CouponID = @CouponID";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponID", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query, parameters);
                return value;
            }
        }

        public async Task<GetCouponCodeDetailByCode> GetCouponCodeDetailByCodeAsync(string code)
        {
            string query = "Select CouponID,CouponCode,CouponRate,CouponValidDate, CouponIsActive from Coupons Where CouponCode = @CouponCode";
            var parameters = new DynamicParameters();
         
            parameters.Add("@CouponCode", code);
            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetCouponCodeDetailByCode>(query, parameters);
                return value;

            }


        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set CouponCode=@CouponCode, CouponRate=@CouponRate, CouponValidDate=@CouponValidDate, CouponIsActive=@CouponIsActive Where CouponID = @CouponID ";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponID", updateCouponDto.CouponID);
            parameters.Add("@CouponCode", updateCouponDto.CouponCode);
            parameters.Add("@CouponRate", updateCouponDto.CouponRate);
            parameters.Add("@CouponValidDate", updateCouponDto.CouponValidDate);
            parameters.Add("@CouponIsActive", updateCouponDto.CouponIsActive);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
        }
    }
}
