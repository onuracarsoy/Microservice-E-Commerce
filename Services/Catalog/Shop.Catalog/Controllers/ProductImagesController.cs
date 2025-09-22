using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Catalog.Dtos.ProductImageDtos;
using Shop.Catalog.Services.ProductImageServices;


namespace Shop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var values = await _productImageService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("GetByProductIDProductImage")]
        public async Task<IActionResult> GetByProductIDProductImage(string id)
        {
            var value = await _productImageService.GetByProductIDProductImageAsync(id);
         
                return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var value = await _productImageService.GetByIdProductImageAsync(id);
            return Ok(value);
        }



        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok();
        }
    }
}
