using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Order.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetByUserIdForAddressAsync(string userID);
        Task<List<T>> GetByUserIdForOrderingAsync(string userID);
        Task<List<T>> GetByUserIdAsync(int userID);
        Task<List<T>> GetByOrderingIdAsync(int orderingID);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);


    }
}
