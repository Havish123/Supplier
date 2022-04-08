using Microsoft.AspNetCore.Mvc;
using SupplierAPI.Models;
using SupplierMVC.Models;
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
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ProductCreateModel model= new ProductCreateModel();
            model.productData=new ProductData();
            model.brands= await _services.GetBrandData();
            model.categories = await _services.GetCategoryData();
            model.suppliers= await _services.GetSupplierData(); 
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ProductCreateModel product)
        {
            //HttpClient client = _api.Initial();

            //var postTask = client.PostAsJsonAsync<StudentData>("api/student", studentData);
            //postTask.Wait();
            //var result = postTask.Result;
            //if (result.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}
            return View();
        }
    }
}
