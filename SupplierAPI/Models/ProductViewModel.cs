namespace SupplierAPI.Models
{
    public class ProductViewModel
    {
        public Product product { get; set; }
        public Supplier Supplier { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public Inventory Inventory { get; set; }

    }
}
