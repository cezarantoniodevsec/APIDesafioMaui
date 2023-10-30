using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Helpers;
using WebApi.Models.Product;


namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices]DataContext context)
        {
            var products = await context.Products.AsNoTracking().ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(null);
            
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest model)
        {
            return Ok(null);
           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductRequest model)
        {
            return Ok(null);
           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(null);
           
        }
    }
}
