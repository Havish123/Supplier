using System.ComponentModel.DataAnnotations;

namespace SupplierMVC.Models
{
    public class BrandData
    {
        [Display(Name ="Brand ID")]
        public int Id { get; set; }
        [Display(Name ="Brand Name")]
        public string Name { get; set; }   
        public virtual ICollection<ProductData> Products { get; set; }
    }
}
