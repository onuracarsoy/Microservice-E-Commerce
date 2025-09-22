using Shop.Cargo.Business.Abstract;
using Shop.Cargo.DataAccess.Abstract;
using Shop.Cargo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Cargo.Business.Concrete
{
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal _cargoDetailDal;

        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            _cargoDetailDal = cargoDetailDal;
        }

        public async Task TDelete(int id)
        {
           await _cargoDetailDal.Delete(id);
        }

        public async Task<List<CargoDetail>> TGetAll()
        {
            return await _cargoDetailDal.GetAll();
        }

        public async Task<CargoDetail> TGetById(int id)
        {
            return await _cargoDetailDal.GetById(id);
        }

        public async Task TInsert(CargoDetail entity)
        {
            await _cargoDetailDal.Insert(entity);
        }

        public async Task<CargoDetail> TInsertWithReturnToId(CargoDetail entity)
        {
            await _cargoDetailDal.InsertWithReturnToId(entity);
            return entity;
        }

        public async Task TUpdate(CargoDetail entity)
        {
            await _cargoDetailDal.Update(entity);
        }
    }
}
