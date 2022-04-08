using Microsoft.AspNetCore.Mvc;

namespace SupplierMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
