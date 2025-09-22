using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Cargo.Business.Abstract;
using Shop.Cargo.Dto.CargoCompanyDtos;
using Shop.Cargo.Entity.Concrete;

namespace Shop.Cargo.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        private readonly IMapper _mapper;

        public CargoCompaniesController(ICargoCompanyService companyService, IMapper mapper)
        {
            _cargoCompanyService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CargoCompanyList()
        {
            var values = await _cargoCompanyService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoCompany(int id)
        {
            var value = await _cargoCompanyService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            var value = _mapper.Map<CargoCompany>(createCargoCompanyDto);
            await _cargoCompanyService.TInsert(value);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCargoCompany(int id)
        {
            await _cargoCompanyService.TDelete(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            var value = _mapper.Map<CargoCompany>(updateCargoCompanyDto);
            await _cargoCompanyService.TUpdate(value);
            return Ok();

        }
    }
}
