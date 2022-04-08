
using Newtonsoft.Json;
using StudentMVC.Helper;
using SupplierAPI.Models;

namespace SupplierMVC.Services
{
    public interface ISupplierService
    {
        public Task<ProductData> GetProductData(int id);
        public Task<List<ProductData>> GetProduct();
        public  Task<CategoryData> GetCategoryData(int id);
        public Task<List<CategoryData>> GetCategoryData();
        public  Task<List<SupplierData>> GetSupplierData();
        public  Task<SupplierData> GetSupplierData(int id);
        public  Task<BrandData> GetBrandData(int id);
        public Task<List<BrandData>> GetBrandData();
    }
    public class SupplierService : ISupplierService
    {
        private string _productApi = "api/products";
        private string _supplierApi = "api/suppliers";
        private string _brandApi = "api/brands";
        private string _categoryApi = "api/categories";
        Supplier_API _api =new Supplier_API();


        //public async Task<List<ProductViewModel>> GetProductData()
        //{
        //    List<ProductViewModel> products=new List<ProductViewModel>();
        //    List<ProductData> product=new List<ProductData>();
        //    HttpClient client = _api.Initial();
        //    HttpResponseMessage res = await client.GetAsync(_productApi);
        //    if (res.IsSuccessStatusCode)
        //    {
        //        var result=res.Content.ReadAsStringAsync().Result;
        //        product=JsonConvert.DeserializeObject<List<ProductData>>(result);
        //    }
        //    product.ForEach(async (product) =>
        //    {
        //        ProductViewModel viewModel=new ProductViewModel();  
        //        viewModel.product=product;
        //        //viewModel.Supplier =await GetSupplierData(product.SupplierId);
        //        //viewModel.Brand = await GetBrandData(product.BrandId);
        //        //viewModel.Category = await GetCategoryData(product.CategoryId);
        //        products.Add(viewModel);
        //    });
        //    return products;
        //}

        //Get Product Data
        public async Task<List<ProductData>> GetProduct()
        {
            List<ProductData> product = new List<ProductData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync(_productApi);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<List<ProductData>>(result);
            }
            return product;
        }
        public async Task<ProductData> GetProductData(int id)
        {
            ProductData product=new ProductData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync(_productApi);
            if (res.IsSuccessStatusCode)
            {
                var result=res.Content.ReadAsStringAsync().Result;
                product=JsonConvert.DeserializeObject<ProductData>(result);
            }
            return product;
        }

        //Get Supplier Data
        public async Task<List<SupplierData>> GetSupplierData()
        {
            List<SupplierData> suppliers = new List<SupplierData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync(_supplierApi);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                suppliers = JsonConvert.DeserializeObject<List<SupplierData>>(result);
            }
            return suppliers;
        }

        public async Task<SupplierData> GetSupplierData(int id)
        {
            SupplierData supplier = new SupplierData();
            HttpClient client = _api.Initial();
            string sd = $"{_supplierApi}/{id}";
            HttpResponseMessage res = await client.GetAsync($"{_supplierApi}/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                supplier = JsonConvert.DeserializeObject<SupplierData>(result);
            }
            return supplier;
        }

        //Brand Data
        public async Task<BrandData> GetBrandData(int id)
        {
            BrandData brand = new BrandData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"{_brandApi}/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                brand = JsonConvert.DeserializeObject<BrandData>(result);
            }
            return brand;
        }

        public async Task<List<BrandData>> GetBrandData()
        {
            List<BrandData> brand = new List<BrandData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync(_brandApi);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                brand = JsonConvert.DeserializeObject<List<BrandData>>(result);
            }
            return brand;
        }

        //Category Data
        public async Task<CategoryData> GetCategoryData(int id)
        {
            CategoryData category = new CategoryData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"{_categoryApi}/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                category = JsonConvert.DeserializeObject<CategoryData>(result);
            }
            return category;
        }
        public async Task<List<CategoryData>> GetCategoryData()
        {
            List<CategoryData> category = new List<CategoryData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync(_categoryApi);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                category = JsonConvert.DeserializeObject<List<CategoryData>>(result);
            }
            return category;
        }
    }
   
}
