using CaseProject.Data.Abstract;
using CaseProject.Entity.Entities;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            List<Category> getAll = await _categoryRepository.FindAllAsync();
            return Ok(getAll);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Category category = await _categoryRepository.FindByIdAsync(id);
            return Ok();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Insert(Category category)
        {
            await _categoryRepository.CreateAsync(category);
            return Ok("Ekleme Başarılı");
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryRepository.DeleteAsync(id);
            return Ok("");
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(Category category)
        {
            Category getCategory = await _categoryRepository.FindByIdAsync(category.Id);
            if (getCategory != null)
            {
                await _categoryRepository.UpdateAsync(category);
            }
            return Ok("");
        }
    }
}
