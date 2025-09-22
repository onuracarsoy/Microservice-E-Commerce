using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Cargo.Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task TInsert(T entity);

        Task TUpdate(T entity);

        Task<T> TInsertWithReturnToId(T entity);

        Task TDelete(int id);

        Task<T> TGetById(int id);

        Task<List<T>> TGetAll();
    }
}
