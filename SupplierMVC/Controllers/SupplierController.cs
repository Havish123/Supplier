﻿using Microsoft.AspNetCore.Mvc;
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
    }
}
