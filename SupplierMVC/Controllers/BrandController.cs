using Microsoft.AspNetCore.Mvc;
using SupplierMVC.Models;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Create(BrandData brand)
        {
            brand.Products=new List<ProductData>();
            var result = _services.CreateBrandData(brand);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var brand = await _services.GetBrandData(id);
            return View(brand);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var brand = await _services.GetBrandData(id);
            return View(brand);
        }

        [HttpPost]
        public async Task<IActionResult> Edit()
        {
            var brand = await _services.GetBrandData();
            return View(brand);
        }
    }
}
