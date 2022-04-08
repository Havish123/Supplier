using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierAPI.Models
{
    public class InventoryData
    {
        
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int stock_product_quantity { get; set; }
    }
}
