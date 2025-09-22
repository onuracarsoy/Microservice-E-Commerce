using Microsoft.EntityFrameworkCore;
using Shop.Cargo.DataAccess.Abstract;
using Shop.Cargo.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Cargo.DataAccess.Repositorties
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly CargoContext _context;

        public GenericRepository(CargoContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            var value = await _context.Set<T>().FindAsync(id);
            _context.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            var values = await _context.Set<T>().ToListAsync();
            return values;
        }

        public async Task<T> GetById(int id)
        {
            var value = await _context.Set<T>().FindAsync(id);
            return value;
        }

        public async Task Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> InsertWithReturnToId(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
