namespace SupplierMVC.Models.ViewModel
{
    public class InventoryViewModel
    {
        public InventoryData inventory { get; set; }
        public ProductData product { get; set; }
        public List<ProductData> products { get; set; }
    }
}
