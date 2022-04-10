using Microsoft.AspNetCore.Mvc;
using SupplierMVC.Models.ViewModel;
using SupplierMVC.Services;

namespace SupplierMVC.Controllers
{
    public class InventoryController : Controller
    {

        private readonly IClientService _services;

        private InventoryViewModel model;
        public InventoryController(IClientService services)
        {
            _services = services;
            model = new InventoryViewModel();

        }
        public async Task<IActionResult> Index(int id)
        {
            if(id == 0)
            {
                model.products = await _services.GetProduct();
                model.inventory = new Models.InventoryData();
                model.product = new Models.ProductData();
            }
            else
            {
                model.products = await _services.GetProduct();
                model.inventory = await _services.GetInventoryData(id);
                model.product = await _services.GetProductData(id);
            }
            
            return View(model);
        }
    }
}
