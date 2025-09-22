using Shop.Cargo.DataAccess.Abstract;
using Shop.Cargo.DataAccess.Concrete;
using Shop.Cargo.DataAccess.Repositorties;
using Shop.Cargo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Cargo.DataAccess.EntityFramework
{
    public class EfCargoOperationDal : GenericRepository<CargoOperation>, ICargoOperationDal
    {
        public EfCargoOperationDal(CargoContext context) : base(context)
        {
        }
    }
}
