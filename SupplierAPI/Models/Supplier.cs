using System.ComponentModel.DataAnnotations;

namespace SupplierAPI.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string supplierBulstat { get; set; }
        public string supplierAddress { get; set; }
        public string supplierEmail { get; set; }
        public string supplierPhone { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
