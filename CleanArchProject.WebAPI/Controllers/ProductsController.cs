using CleanArchProject.Application.DTOs;
using CleanArchProject.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchProject.WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get() {
            var products = await _productService.GetProducts();
            if (products == null) return NotFound("Products not found");
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound("Product not found");
            return Ok(product);
        }

        [HttpGet("ByCategory/{id:int}")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductByCategoryId(int id)
        {
            var product = await _productService.GetProductByCategoryId(id);
            if (product == null) return NotFound("Product not found");
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDto)
        {
            if (productDto == null) return BadRequest("Invalid Data");
            await _productService.Add(productDto);
            return CreatedAtAction(nameof(Create), productDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ProductDTO productDto)
        {
            if (id != productDto.Id) return BadRequest("Not corresponding data");

            var existingCategory = await _productService.GetProductById(id);
            if (existingCategory is null) return NotFound("There's nothing to update");

            await _productService.Update(productDto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingProduct = await _productService.GetProductById(id);
            if (existingProduct is null)
                return NotFound("Product not found");
            await _productService.Delete(id);
            return NoContent();
        }
    }
}
