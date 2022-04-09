using Microsoft.AspNetCore.Mvc;
using SupplierMVC.Services;

namespace SupplierMVC.Controllers
{
    public class BrandController : Controller
    {
        private readonly IClientService _services;
        public BrandController(IClientService services)
        {
            _services = services;


        }
        public async Task<IActionResult> Index()
        {
            return View(await _services.GetBrandData());
        }
    }
}
