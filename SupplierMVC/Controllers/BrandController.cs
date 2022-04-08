using Microsoft.AspNetCore.Mvc;
using SupplierMVC.Services;

namespace SupplierMVC.Controllers
{
    public class BrandController : Controller
    {
        private readonly ISupplierService _services;
        public BrandController(ISupplierService services)
        {
            _services = services;


        }
        public async Task<IActionResult> Index()
        {
            return View(await _services.GetBrandData());
        }
    }
}
