using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Cargo.Business.Abstract;
using Shop.Cargo.Dto.CargoOperationDtos;
using Shop.Cargo.Entity.Concrete;

namespace Shop.Cargo.WebApi.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;
        private readonly IMapper _mapper;

        public CargoOperationsController(ICargoOperationService companyService, IMapper mapper)
        {
            _cargoOperationService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CargoOperationList()
        {
            var values = await _cargoOperationService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoOperation(int id)
        {
            var value = await _cargoOperationService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            var value = _mapper.Map<CargoOperation>(createCargoOperationDto);
           var cargoOperation =  await _cargoOperationService.TInsertWithReturnToId(value);
            return Ok(cargoOperation.CargoOperationID);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCargoOperation(int id)
        {
            await _cargoOperationService.TDelete(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            var value = _mapper.Map<CargoOperation>(updateCargoOperationDto);
            await _cargoOperationService.TUpdate(value);
            return Ok();

        }
    }
}
