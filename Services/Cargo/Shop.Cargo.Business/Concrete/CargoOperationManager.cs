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
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal _cargoOperationDal;

        public CargoOperationManager(ICargoOperationDal cargoOperationDal)
        {
            _cargoOperationDal = cargoOperationDal;
        }

        public async Task TDelete(int id)
        {
            await _cargoOperationDal.Delete(id);
        }

        public async Task<List<CargoOperation>> TGetAll()
        {
            return await _cargoOperationDal.GetAll();
        }

        public async Task<CargoOperation> TGetById(int id)
        {
            return await _cargoOperationDal.GetById(id);
        }

        public async Task TInsert(CargoOperation entity)
        {
            await _cargoOperationDal.Insert(entity);
        }

        public async Task<CargoOperation> TInsertWithReturnToId(CargoOperation entity)
        {
            await _cargoOperationDal.InsertWithReturnToId(entity);
            return entity;
        }

        public async Task TUpdate(CargoOperation entity)
        {
            await _cargoOperationDal.Update(entity);
        }
    }
}
