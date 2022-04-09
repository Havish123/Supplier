using SupplierMVC.Models;

namespace SupplierMVC.Models
{
    public class ProductCreateModel
    {
        public ProductData productData { get; set; }
        public IEnumerable<CategoryData> categories { get; set; }
        public IEnumerable<SupplierData> suppliers { get; set; }
        public IEnumerable<BrandData> brands { get; set; }
    }
}
