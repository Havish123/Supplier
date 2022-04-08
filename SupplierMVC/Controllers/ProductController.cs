using Microsoft.AspNetCore.Mvc;
using SupplierMVC.Services;

namespace SupplierMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ISupplierService _services;
        public ProductController(ISupplierService services)
        {
            _services = services;

        }
        public async Task<IActionResult> Index()
        {
            //var data = await _services.GetProductData();
            return View(await _services.GetProductData());
        }
    }
}
