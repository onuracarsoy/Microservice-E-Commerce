using Microsoft.EntityFrameworkCore;
using Shop.Order.Application.Interfaces;
using Shop.Order.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Order.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OrderContext _context;

        public Repository(OrderContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetByOrderingIdAsync(int orderID)
        {
            return await _context.Set<T>()
                                 .Where(entity => EF.Property<int>(entity, "OrderingID") == orderID)
                                 .ToListAsync();
        }

        public async Task<List<T>> GetByUserIdForAddressAsync(string userID)
        {
            return await _context.Set<T>()
                                 .Where(entity => EF.Property<string>(entity, "UserID") == userID)
                                 .ToListAsync();
        }

        public async Task<List<T>> GetByUserIdForOrderingAsync(string userID)
        {
            return await _context.Set<T>()
                                 .Where(entity => EF.Property<string>(entity, "UserID") == userID)
                                  .OrderByDescending(entity => EF.Property<DateTime>(entity, "OrderDate"))
                                 .ToListAsync();
        }

        public async Task<List<T>> GetByUserIdAsync(int userID)
        {
            return await _context.Set<T>()
                                 .Where(entity => EF.Property<int>(entity, "UserID") == userID)
                                 .ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
           _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync(); 
        }
    }
}
