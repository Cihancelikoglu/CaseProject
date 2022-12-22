using CaseProject.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaseProject.MVC.Controllers
{
    public class ProductsDetailController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductsDetailController(IProductService productService, ICategoryService categoryService)
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

        public async Task<IActionResult> Detail(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            ViewBag.category = await _categoryService.GetByIdAsync(result.Data.Id);
            return View(result.Data);
        }
    }
}
