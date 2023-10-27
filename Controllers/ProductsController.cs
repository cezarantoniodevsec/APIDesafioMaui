using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Product;
using WebApi.Services;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Products = await _productService.GetAll();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Product = await _productService.GetById(id);
            return Ok(Product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest model)
        {
            await _productService.Create(model);
            return Ok(new { message = "Product created" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductRequest model)
        {
            await _productService.Update(id, model);
            return Ok(new { message = "Product updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Delete(id);
            return Ok(new { message = "Product deleted" });
        }
    }
}
