﻿using Microsoft.AspNetCore.Mvc;
using SupplierMVC.Services;

namespace SupplierMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IClientService _services;
        public CategoryController(IClientService services)
        {
            _services = services;


        }
        public async Task<IActionResult> Index()
        {
            return View(await _services.GetCategoryData());
        }
    }
}
