using Microsoft.AspNetCore.Mvc;
using SupplierMVC.Models;
using SupplierMVC.Services;

namespace SupplierMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IClientService _services;
        public CategoryController(IClientService services)
        {
            _services = services;


        }

        //Index Home Page for show the list of Categories
        public async Task<IActionResult> Index(string SearchString)
        {
            var categories = await _services.GetCategoryData();
            if (!String.IsNullOrEmpty(SearchString))
            {
                categories = categories.Where(c => c.CategoryName.Contains(SearchString)).ToList();
            }
            return View(categories);
        }

        //HttpGet Method for Navigate to the Edit Page
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _services.GetCategoryData(id);
            return View(category);
        }

        //Post method for apply the changes in the database
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryData category)
        {
            category.Products = new List<ProductData>();
            var result = _services.EditCategoryData(category);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //HttpGet Method to Navigate the Create Page
        public IActionResult Create()
        {
            return View();
        }

        //HttpPost method for Store the Data
        [HttpPost]
        public IActionResult Create(CategoryData category)
        {
            category.Products = new List<ProductData>();
            var result = _services.CreateCategoryData(category);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //Http Get Method for View The Category Details
        public async Task<IActionResult> Details(int id)
        {
            var category = await _services.GetCategoryData(id);
            return View(category);
        }

        //Delete the Data into the Database
        public async Task<IActionResult> Delete(int id)
        {
            bool res = await _services.DeleteCategoryData(id);
            if (res)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
