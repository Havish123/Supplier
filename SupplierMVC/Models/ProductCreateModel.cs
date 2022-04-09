using SupplierMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace SupplierMVC.Models
{
    public class ProductCreateModel
    {
        public ProductData productData { get; set; }
        [Display(Name ="Categories")]
        public IEnumerable<CategoryData> categories { get; set; }
        [Display(Name ="Suppliers")]
        public IEnumerable<SupplierData> suppliers { get; set; }
        [Display(Name ="Brands")]
        public IEnumerable<BrandData> brands { get; set; }
    }
}
