using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Catalog.Services.StatisticServices;

namespace Shop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("TotalProductCount")]
        public async Task<IActionResult> TotalProductCount()
        {
            var value = await _statisticService.TotalProductCount();
            return Ok(value);
        }

        [HttpGet("TotalCategoryCount")]
        public async Task<IActionResult> TotalCategoryCount()
        {
            var value = await _statisticService.TotalCategoryCount();
            return Ok(value);
        }
    }
}
