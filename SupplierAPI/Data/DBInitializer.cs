using SupplierAPI.Models;

namespace SupplierAPI.Data
{
    public static class DBInitializer
    {
        public static void Initializer(SupplierDBContext context)
        {
            if (!context.Categories.Any())
            {
                List<Category> category = new List<Category>()
                {
                    new Category{Name="Mobiles"},
                    new Category{Name="Wearables"},
                    new Category{Name="TeleVision"},
                    new Category{Name="Set Top Boxes"},
                    new Category{Name="Monitors"},
                    new Category{Name="Laptops"},
                    new Category{Name="Tablets"},
                    new Category{Name="Computers"},
                    new Category{Name="Printers"},
                    new Category{Name="Scanners"},
                };
                context.Categories.AddRange(category);
                context.SaveChanges();
            }
            if (!context.Brands.Any())
            {
                List<Brand> brands = new List<Brand>() {
                    new Brand{Name="Redmi"},
                    new Brand{Name="Samsung"},
                    new Brand{Name="HP"},
                    new Brand{Name="POCO"},
                    new Brand{Name="Acer"},
                    new Brand{Name="Asus"},
                    new Brand{Name="Apple"},
                    new Brand{Name="Realme"},
                    new Brand{Name="Sony"},
                    new Brand{Name="Oneplus"},
                };

                context.Brands.AddRange(brands);
                context.SaveChanges();
            }
            if (!context.Suppliers.Any()) {
                List<Supplier> suppliers = new List<Supplier>() {
                    new Supplier{
                        Name="Deepak",
                        supplierEmail="deepakraj@gmail.com",
                        supplierPhone="1234567890",
                        supplierAddress="Madurai",
                        supplierBulstat="118585306",

                    },new Supplier{
                        Name="Dharani",
                        supplierEmail="dharani@gmail.com",
                        supplierPhone="1234567890",
                        supplierAddress="Coimbatore",
                        supplierBulstat="118585305",

                    },new Supplier{
                        Name="Vinil",
                        supplierEmail="vinil@gmail.com",
                        supplierPhone="1234567890",
                        supplierAddress="Tirunelveli",
                        supplierBulstat="118585303",

                    },new Supplier{
                        Name="Sudharshan",
                        supplierEmail="sudharshan@gmail.com",
                        supplierPhone="1234567890",
                        supplierAddress="Theni",
                        supplierBulstat="118585302",

                    },new Supplier{
                        Name="Suwathi",
                        supplierEmail="suwathi@gmail.com",
                        supplierPhone="1234567890",
                        supplierAddress="Tirupur",
                        supplierBulstat="118585301",

                    },
                };
                context.Suppliers.AddRange(suppliers);
                context.SaveChanges();
            }


        }

    }
}
