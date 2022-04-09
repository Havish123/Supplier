using Microsoft.AspNetCore.Mvc;

using SupplierMVC.Models;
using SupplierMVC.Services;

namespace SupplierMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IClientService _services;
        private  List<ProductViewModel> _productViewModels { get; set; }
        public ProductController(IClientService services)
        {
            _services = services;
            

        }

        //Product Home Page
        public async Task<IActionResult> Index(string SearchString)
        {
            
            _productViewModels = await  GetProductViewModel(SearchString);

            return View(_productViewModels);
        }

        //Create Get Method for View The Page
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
        //Create Post Method for Storing Product Data into Database
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateModel product)
        {

            var result = _services.CreateProductData(product.productData);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View(_productViewModels);
        }


        //Get Method to View the particular Product Details
        public async Task<IActionResult> Details(int id)
        {
            ProductDetailsModel model=new ProductDetailsModel();
            model = await GetData(id);
            return View(model);
        }

        //Get the Data with the type of Product Details Model
        public async Task<ProductDetailsModel> GetData(int id)
        {
            ProductDetailsModel modeldata=new ProductDetailsModel();
            modeldata.Product= await _services.GetProductData(id);
            modeldata.brand = await _services.GetBrandData(modeldata.Product.BrandId);
            modeldata.Supplier= await _services.GetSupplierData(modeldata.Product.SupplierId);
            modeldata.category= await _services.GetCategoryData(modeldata.Product.CategoryId);
            return modeldata;


        }

        //Get the Data with the type of Product View Model
        public async Task<List<ProductViewModel>> GetProductViewModel(string SearchString)
        {
            _productViewModels = new List<ProductViewModel>();
            List<ProductData> product = new List<ProductData>();
             product = await _services.GetProduct();
            if (!String.IsNullOrEmpty(SearchString))
            {
                product = product.Where(p => p.product_Name!.Contains(SearchString)).ToList();
            }
            //var data = await _services.GetProductData();

            foreach (var p in product)
            {
                ProductViewModel pvModel = new ProductViewModel();
                pvModel.product = p;
                pvModel.Supplier = await _services.GetSupplierData(p.SupplierId);
                pvModel.Brand = await _services.GetBrandData(p.BrandId);
                pvModel.Category = await _services.GetCategoryData(p.CategoryId);
                _productViewModels.Add(pvModel);
            }
            return _productViewModels;

        }
        

        //Edit Method for View The data in Edit Page
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ProductCreateModel model = new ProductCreateModel();
            model.productData =await _services.GetProductData(id);
            model.brands = await _services.GetBrandData();
            model.categories = await _services.GetCategoryData();
            model.suppliers = await _services.GetSupplierData();
            return View(model);

        }

        //Post method for update the data into database
        [HttpPost]
        public async Task<IActionResult> Edit(ProductCreateModel product)
        {
            
            var result = _services.EditProductData(product.productData);
            if (result)
            {
                return RedirectToAction("Index");
            }
            ProductCreateModel model = new ProductCreateModel();
            model.productData = await _services.GetProductData(product.productData.product_Id);
            model.brands = await _services.GetBrandData();
            model.categories = await _services.GetCategoryData();
            model.suppliers = await _services.GetSupplierData();
            return View(model);
        }

       
        //Delete  method for Delete the product Data
        public async Task<IActionResult> Delete(int id)
        {
            bool res = await _services.DeleteProductData(id);
            if (res)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
