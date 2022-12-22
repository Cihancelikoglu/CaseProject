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

        public IActionResult Index()
        {
            return View();
        }
    }
}
