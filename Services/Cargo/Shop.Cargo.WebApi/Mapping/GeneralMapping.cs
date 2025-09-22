using AutoMapper;
using Shop.Cargo.Dto.CargoCompanyDtos;
using Shop.Cargo.Dto.CargoCustomerDtos;
using Shop.Cargo.Dto.CargoDetailDtos;
using Shop.Cargo.Dto.CargoOperationDtos;
using Shop.Cargo.Entity.Concrete;

namespace Shop.Cargo.WebApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CargoCompany,CreateCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany,UpdateCargoCompanyDto>().ReverseMap();

            CreateMap<CargoCustomer, CreateCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, UpdateCargoCustomerDto>().ReverseMap();

            CreateMap<CargoDetail, CreateCargoDetailDto>().ReverseMap();
            CreateMap<CargoDetail, UpdateCargoDetailDto>().ReverseMap();

            CreateMap<CargoOperation, CreateCargoOperationDto>().ReverseMap();
            CreateMap<CargoOperation, UpdateCargoOperationDto>().ReverseMap();
        }
    }
}
