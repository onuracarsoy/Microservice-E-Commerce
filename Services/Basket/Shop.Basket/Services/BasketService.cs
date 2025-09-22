using Shop.Basket.Dtos;
using Shop.Basket.Settings;
using System.Text.Json;

namespace Shop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
            await _redisService.GetDb().KeyDeleteAsync(userId);

        }

        public async Task<BasketTotalDto> GetBasket(string userId)
        {
            // Redis'ten kullanıcıya ait sepeti al
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);

            // Eğer sepet yoksa yeni bir sepet oluştur
            if (existBasket.IsNullOrEmpty)
            {
                // Yeni bir sepet oluştur
                var newBasket = new BasketTotalDto
                {
                    UserID = userId,
                    BasketItems = new List<BasketItemDto>(),
                    DiscountCode = "",
                    DiscountRate = 0
                   
                };
                var serializedBasket = JsonSerializer.Serialize(newBasket);
                await _redisService.GetDb().StringSetAsync(userId, serializedBasket);

                return newBasket;
            }

            
            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserID,JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
