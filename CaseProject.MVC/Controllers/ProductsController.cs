using CaseProject.Business.Abstract;
using CaseProject.Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaseProject.MVC.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _productService.GetAllAsync();
            ViewBag.product = result.Data;

            return View(result.Data);
        }

        public async Task<IActionResult> ProductAdd()
        {
            var result = await _categoryService.GetAllAsync();
            ViewBag.category = result.Data;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductAdd([FromForm] IFormFile file, [FromForm] Product product)
        {
            var result = await _productService.AddAsync(file, product);
            if (result.IsSuccess)
            {   
                return RedirectToAction("Index");
            }
            return BadRequest(result);
        }

        public async Task<IActionResult> ProductUpdate(int id)
        {
            var result = await _categoryService.GetAllAsync();
            ViewBag.category = result.Data;
            var product = await _productService.GetByIdAsync(id);
            return View(product.Data);
        }

        [HttpPost]
        public async Task<IActionResult> ProductUpdate([FromForm] IFormFile file, [FromForm] Product product)
        {
            var result = await _productService.UpdateAsync(file, product);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return BadRequest(result);
        }

        public async Task<IActionResult> ProductDelete(int id)
        {
            var result = await _productService.DeleteAsync(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return BadRequest(result);
        }

        public async Task<IActionResult> IsStatus(int id)
        {
            var result = await _productService.IsStatus(id);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return BadRequest(result);
        }
    }
}
