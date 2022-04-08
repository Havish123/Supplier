using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentMVC.Helper;
using SupplierAPI.Models;

namespace SupplierMVC.Controllers
{
    public class SupplierController : Controller
    {
        Supplier_API _api=new Supplier_API();
        public async Task<IActionResult> Index()
        {
            List<SupplierData> suppliers = new List<SupplierData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/suppliers");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                suppliers = JsonConvert.DeserializeObject<List<SupplierData>>(results);
            }
            return View(suppliers);
        }
    }
}
