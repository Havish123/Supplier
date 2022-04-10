using System.ComponentModel.DataAnnotations;

namespace SupplierMVC.Models
{
    public class SupplierData
    {
        [Display(Name ="Supplier ID")]
        public int Id { get; set; }
        [Display(Name ="Supplier Name")]
        public string Name { get; set; }
        [Display(Name ="Bulstat")]
        public string supplierBulstat { get; set; }
        [Display(Name ="Address")]
        public string supplierAddress { get; set; }
        [Display(Name ="Email")]
        public string supplierEmail { get; set; }
        [Display(Name ="Phone Number")]
        public string supplierPhone { get; set; }

        public virtual ICollection<ProductData> Products { get; set; }

    }
}
