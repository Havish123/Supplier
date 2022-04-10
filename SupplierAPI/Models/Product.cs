using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SupplierAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public double product_price { get; set; }

       
        public virtual Inventory inventory { get; set; }
    }
}
