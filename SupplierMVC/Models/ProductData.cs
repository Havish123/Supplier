using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SupplierMVC.Models
{
    public class ProductData
    {
        [Display(Name ="Product ID")]
        public int Id { get; set; }
        [Display(Name ="Product Name")]
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        [Display(Name ="Price")]        
        public double product_price { get; set; }

       
        public virtual InventoryData inventory { get; set; }
    }
}
