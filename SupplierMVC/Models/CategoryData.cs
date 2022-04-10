using System.ComponentModel.DataAnnotations;

namespace SupplierMVC.Models
{
    public class CategoryData
    {
        [Display(Name ="Category ID")]
        public int Id { get; set; }
        [Display(Name ="Category Name")]
        public string Name { get; set; }

        public virtual ICollection<ProductData> Products { get; set; }
    }
}
