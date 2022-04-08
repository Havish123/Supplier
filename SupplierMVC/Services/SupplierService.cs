
using Newtonsoft.Json;
using StudentMVC.Helper;
using SupplierAPI.Models;

namespace SupplierMVC.Services
{
    public interface ISupplierService
    {
        public Task<List<ProductViewModel>> GetProductData();
        public Task<ProductData> GetProductData(int id);
    }
    public class SupplierService : ISupplierService
    {
        private string _productApi = "api/products";
        private string _supplierApi = "api/suppliers";
        private string _brandApi = "api/brands";
        private string _categoryApi = "api/categories";
        Supplier_API _api =new Supplier_API();
        public async Task<List<ProductViewModel>> GetProductData()
        {
            List<ProductViewModel> products=new List<ProductViewModel>();
            List<ProductData> product=new List<ProductData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync(_productApi);
            if (res.IsSuccessStatusCode)
            {
                var result=res.Content.ReadAsStringAsync().Result;
                product=JsonConvert.DeserializeObject<List<ProductData>>(result);
            }
            product.ForEach(async (product) =>
            {
                ProductViewModel viewModel=new ProductViewModel();  
                viewModel.product=product;
                viewModel.Supplier =await GetSupplierData(product.SupplierId);
                viewModel.Brand = await GetBrandData(product.BrandId);
                viewModel.Category = await GetCategoryData(product.CategoryId);
                products.Add(viewModel);
            });
            return products;
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

        public async void GetSupplierData()
        {
            ProductData product = new ProductData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync(_supplierApi);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<ProductData>(result);
            }
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
    }
}
