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
        //Index Home Page for show the list of Brands
        public async Task<IActionResult> Index(string SearchString)
        {
            var suppliers = await _services.GetSupplierData();
            if (!String.IsNullOrEmpty(SearchString))
            {
                suppliers=suppliers.Where( s => s.supplierName.Contains(SearchString)).ToList();
            }
            return View(suppliers);
        }

        //HttpGet Method to Navigate the Create Page
        public IActionResult Create()
        {
            return View();
        }

        //HttpPost method for Store the Data
        [HttpPost]
        public IActionResult Create(SupplierData supplier)
        {
            supplier.Products = new List<ProductData>();
            var result = _services.CreateSupplierData(supplier);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //Http Get Method for View The Supplier Details
        public async Task<IActionResult> Details(int id)
        {
            var suppliers = await _services.GetSupplierData(id);
            return View(suppliers);
        }


        //HttpGet Method for Navigate to the Edit Page
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            
            return View(await _services.GetSupplierData(id));

        }

        //Post method for apply the changes in the database
        [HttpPost]
        public IActionResult Edit(SupplierData supplier)
        {
            supplier.Products = new List<ProductData>();
            var result = _services.EditSupplierData(supplier);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //Delete the Data into the Database
        public async Task<IActionResult> Delete(int id)
        {
            bool res = await _services.DeleteSupplierData(id);
            if (res)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
