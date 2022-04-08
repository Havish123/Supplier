using SupplierAPI.Models;

namespace SupplierMVC.Models
{
    public class ProductCreateModel
    {
        public ProductData productData { get; set; }
        public List<CategoryData> categories { get; set; }
        public List<SupplierData> suppliers { get; set; }
        public List<BrandData> brands { get; set; }
    }
}
