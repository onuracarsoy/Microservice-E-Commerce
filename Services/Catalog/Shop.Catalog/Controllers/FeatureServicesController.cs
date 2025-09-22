using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Catalog.Dtos.FeatureServiceDtos;
using Shop.Catalog.Services.FeatureServices;


namespace Shop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureServicesController : ControllerBase
    {
        private readonly IFeatureServiceService _featureServiceService;

        public FeatureServicesController(IFeatureServiceService featureServiceService)
        {
            _featureServiceService = featureServiceService;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureServiceList()
        {
            var values = await _featureServiceService.GetAllFeatureServiceAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureServiceById(string id)
        {
            var value = await _featureServiceService.GetByIdFeatureServiceAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureService(CreateFeatureServiceDto createFeatureServiceDto)
        {
            await _featureServiceService.CreateFeatureServiceAsync(createFeatureServiceDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeatureService(string id)
        {
            await _featureServiceService.DeleteFeatureServiceAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeatureService(UpdateFeatureServiceDto updateFeatureServiceDto)
        {
            await _featureServiceService.UpdateFeatureServiceAsync(updateFeatureServiceDto);
            return Ok();
        }

    }
}
