using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Cargo.Business.Abstract;
using Shop.Cargo.Dto.CargoDetailDtos;
using Shop.Cargo.Entity.Concrete;

namespace Shop.Cargo.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;
        private readonly IMapper _mapper;

        public CargoDetailsController(ICargoDetailService companyService, IMapper mapper)
        {
            _cargoDetailService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CargoDetailList()
        {
            var values = await _cargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoDetail(int id)
        {
            var value = await _cargoDetailService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            var value = _mapper.Map<CargoDetail>(createCargoDetailDto);
           var cargoDetail =  await _cargoDetailService.TInsertWithReturnToId(value);
            return Ok(cargoDetail.CargoDetailID);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCargoDetail(int id)
        {
            await _cargoDetailService.TDelete(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            var value = _mapper.Map<CargoDetail>(updateCargoDetailDto);
            await _cargoDetailService.TUpdate(value);
            return Ok();

        }
    }
}
