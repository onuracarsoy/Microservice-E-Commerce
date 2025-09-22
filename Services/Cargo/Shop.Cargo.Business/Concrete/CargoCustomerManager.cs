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
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDal _cargoCustomerDal;

        public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
        {
            _cargoCustomerDal = cargoCustomerDal;
        }

        public async Task TDelete(int id)
        {
            await _cargoCustomerDal.Delete(id);
        }

        public async Task<List<CargoCustomer>> TGetAll()
        {
            return await _cargoCustomerDal.GetAll();
        }

        public async Task<CargoCustomer> TGetById(int id)
        {
            return await _cargoCustomerDal.GetById(id);
        }

        public async Task TInsert(CargoCustomer entity)
        {
            await _cargoCustomerDal.Insert(entity);
        }

        public async Task<CargoCustomer> TInsertWithReturnToId(CargoCustomer entity)
        {
            await _cargoCustomerDal.InsertWithReturnToId(entity);
            return entity;
        }

        public async Task TUpdate(CargoCustomer entity)
        {
            await _cargoCustomerDal.Update(entity);
        }
    }
}
