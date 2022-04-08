using System.ComponentModel.DataAnnotations;

namespace SupplierAPI.Models
{
    public class BrandData
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }   
        public virtual ICollection<ProductData> Products { get; set; }
    }
}
