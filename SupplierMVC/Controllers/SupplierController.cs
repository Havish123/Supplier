using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentMVC.Helper;
using SupplierAPI.Models;
using SupplierMVC.Services;

namespace SupplierMVC.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _services;
        public SupplierController(ISupplierService services)
        {
            _services = services;


        }
        public async Task<IActionResult> Index()
        {
            
            return View(await _services.GetSupplierData());
        }

        public async Task<IActionResult> Details(int id)
        {
            
            return View(await _services.GetSupplierData(id));
        }

        public IActionResult Create(SupplierData supplier)
        {
            //HttpClient client = _api.Initial();

            //var postTask = client.PostAsJsonAsync<StudentData>("api/student", studentData);
            //postTask.Wait();
            //var result = postTask.Result;
            //if (result.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            
            return View(await _services.GetSupplierData(id));

        }

        [HttpPost]
        public IActionResult Edit(SupplierData supplier)
        {
            //HttpClient client = _api.Initial();

            //var postTask = client.PutAsJsonAsync<StudentData>($"api/student/{studentData.Id}", studentData);
            //postTask.Wait();
            //var result = postTask.Result;
            //if (result.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            //var student = new StudentData();
            //HttpClient client = _api.Initial();
            //HttpResponseMessage res = await client.DeleteAsync($"api/student/{id}");
            return RedirectToAction("Index");

        }
    }
}
