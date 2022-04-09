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

        //Index Home Page for show the list of Brands
        public async Task<IActionResult> Index(string SearchString)
        {
            var brands=await _services.GetBrandData();
            if (!String.IsNullOrEmpty(SearchString))
            {
                brands=brands.Where(b => b.BrandName.Contains(SearchString)).ToList();
            }
            return View(brands);
        }


        //HttpGet Method to Navigate the Create Page
        public IActionResult Create()
        {
            return View();
        }

        //HttpPost method for Store the Data
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

        //Http Get Method for View The Brand Details
        public async Task<IActionResult> Details(int id)
        {
            var brand = await _services.GetBrandData(id);
            return View(brand);
        }

        //HttpGet Method for Navigate to the Edit Page
        public async Task<IActionResult> Edit(int id)
        {
            var brand = await _services.GetBrandData(id);
            return View(brand);
        }

        //Post method for apply the changes in the database
        [HttpPost]
        public async Task<IActionResult> Edit(BrandData brand)
        {
            brand.Products= new List<ProductData>();
            var result = _services.EditBrandData(brand);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //Delete the Data into the Database
        public async Task<IActionResult> Delete(int id)
        {
            bool res=await _services.DeleteBrandData(id);
            if (res)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    
        
    }
}
