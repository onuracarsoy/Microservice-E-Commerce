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
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompanyDal;

        public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
        {
            _cargoCompanyDal = cargoCompanyDal;
        }

        public async Task TDelete(int id)
        {
            await _cargoCompanyDal.Delete(id);
        }

        public async Task<List<CargoCompany>> TGetAll()
        {
            return await _cargoCompanyDal.GetAll();
        }

        public async Task<CargoCompany> TGetById(int id)
        {
            return await _cargoCompanyDal.GetById(id);
        }

        public async Task TInsert(CargoCompany entity)
        {
            await _cargoCompanyDal.Insert(entity);
        }

        public async Task<CargoCompany> TInsertWithReturnToId(CargoCompany entity)
        {
            await _cargoCompanyDal.InsertWithReturnToId(entity);
            return entity;
        }

        public async Task TUpdate(CargoCompany entity)
        {
            await _cargoCompanyDal.Update(entity);
        }
    }
}
