using CaseProject.Business.Abstract;
using CaseProject.Data.Abstract;
using CaseProject.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CaseProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAllAsync();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Product product)
        {
            var result = await _productService.AddAsync(product);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(Product product)
        {
            var result = await _productService.UpdateAsync(product);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok("");
        }
    }
}
