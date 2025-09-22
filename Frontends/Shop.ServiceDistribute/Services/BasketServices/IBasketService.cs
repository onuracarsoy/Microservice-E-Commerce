using Shop.ServiceDistribute.Dtos;
using Shop.ServiceDistribute.Dtos.BasketDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.BasketServices
{
    public interface IBasketService
    {
        Task AddBasketItemAsync (BasketItemDto basketItemDto);

        Task<bool> RemoveBasketItemAsync(string productID);


        Task<BasketTotalDto> GetBasketAsync();

        Task SaveBasketAsync(BasketTotalDto basketTotalDto);

        Task DeleteBasketAsync(string userId);
    }
}
