using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Cargo.Business.Abstract;
using Shop.Cargo.Dto.CargoCustomerDtos;
using Shop.Cargo.Entity.Concrete;

namespace Shop.Cargo.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;
        private readonly IMapper _mapper;

        public CargoCustomersController(ICargoCustomerService companyService, IMapper mapper)
        {
            _cargoCustomerService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CargoCustomerList()
        {
            var values = await _cargoCustomerService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoCustomer(int id)
        {
            var value = await _cargoCustomerService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            var value = _mapper.Map<CargoCustomer>(createCargoCustomerDto);
            var customerService = await _cargoCustomerService.TInsertWithReturnToId(value);
            return Ok(customerService.CargoCustomerID);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCargoCustomer(int id)
        {
            await _cargoCustomerService.TDelete(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            var value = _mapper.Map<CargoCustomer>(updateCargoCustomerDto);
            await _cargoCustomerService.TUpdate(value);
            return Ok();

        }
    }
}
