using System.ComponentModel.DataAnnotations;

namespace SupplierAPI.Models
{
    public class CategoryData
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<ProductData> Products { get; set; }
    }
}
