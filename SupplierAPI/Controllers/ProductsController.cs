#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupplierAPI.Data;
using SupplierAPI.Models;
using SupplierAPI.Services;

namespace SupplierAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SupplierDBContext _context;
        private readonly IProductService _services;
        public ProductsController(IProductService services )
        {
            _services = services;
        }
        

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _services.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetQuestion(int id)
        {
            return await _services.Get(id);
        }

        //// PUT: api/Questions/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, Product product)
        {
            if (id != product.product_Id)
            {
                return BadRequest();
            }
            await _services.Update(product);
            return NoContent();
        }

        //// POST: api/Questions
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostQuestion(Product product)
        {
            var newProduct = await _services.Create(product);
            return CreatedAtAction(nameof(GetQuestion), new { id = newProduct.product_Id }, newProduct);

        }

        //// DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var product = await _services.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            await _services.Delete(id);
            return NoContent();
        }


    }
}
