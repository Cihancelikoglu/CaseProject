using CaseProject.Business.Abstract;
using CaseProject.Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaseProject.MVC.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAllAsync();
            ViewBag.categories = result.Data;

            return View(result.Data);
        }

        public async Task<IActionResult> CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CategoryAdd(Category category)
        {
            var result = await _categoryService.AddAsync(category);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return BadRequest(result);
        }

        public async Task<IActionResult> CategoryUpdate(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return View(category.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CategoryUpdate(Category category)
        {
            var result = await _categoryService.UpdateAsync(category);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return BadRequest(result);
        }

        public async Task<IActionResult> CategoryDelete(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return BadRequest(result);
        }

        public async Task<IActionResult> IsStatus(int id)
        {
            var result = await _categoryService.IsStatus(id);
            
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return BadRequest(result);
        }
    }
}
