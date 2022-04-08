using Microsoft.AspNetCore.Mvc;
using SupplierAPI.Models;
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
            List<ProductViewModel> products = new List<ProductViewModel>();
            List<ProductData> product = new List<ProductData>();
            product = await _services.GetProduct();
            //var data = await _services.GetProductData();

            foreach(var p in product)
            {
                ProductViewModel pvModel=new ProductViewModel();
                pvModel.product = p;
                pvModel.Supplier= await _services.GetSupplierData(p.SupplierId);
                pvModel.Brand= await _services.GetBrandData(p.BrandId);
                pvModel.Category= await _services.GetCategoryData(p.CategoryId);
                products.Add(pvModel);
            }

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
