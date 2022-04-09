using System.ComponentModel.DataAnnotations;

namespace SupplierMVC.Models
{
    public class BrandData
    {
        [Display(Name ="Brand ID")]
        public int BrandId { get; set; }
        [Display(Name ="Brand Name")]
        public string BrandName { get; set; }   
        public virtual ICollection<ProductData> Products { get; set; }
    }
}
