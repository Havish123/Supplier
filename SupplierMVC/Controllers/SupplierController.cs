using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SupplierMVC.Helper;
using SupplierMVC.Models;
using SupplierMVC.Services;

namespace SupplierMVC.Controllers
{
    public class SupplierController : Controller
    {
        private readonly IClientService _services;
        public SupplierController(IClientService services)
        {
            _services = services;


        }
        public async Task<IActionResult> Index()
        {
            
            return View(await _services.GetSupplierData());
        }

        public async Task<IActionResult> Details(int id)
        {
            var suppliers = await _services.GetSupplierData(id);
            return View(suppliers);
        }

        public IActionResult Create(SupplierData supplier)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            
            return View(await _services.GetSupplierData(id));

        }

        [HttpPost]
        public IActionResult Edit(SupplierData supplier)
        {
           
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            
            return RedirectToAction("Index");

        }
    }
}
