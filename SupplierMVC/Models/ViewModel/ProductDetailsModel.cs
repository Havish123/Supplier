namespace SupplierMVC.Models
{
    public class ProductDetailsModel
    {
        public ProductData Product { get; set; }
        public SupplierData Supplier { get; set; }
        public CategoryData category { get; set; }
        public BrandData brand { get; set; }
    }
}
