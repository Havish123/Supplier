using Microsoft.AspNetCore.Mvc;
using SupplierAPI.Models;
using SupplierAPI.Services;

namespace SupplierAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _services;
        public InventoryController(IInventoryService services)
        {
            _services = services;
        }


        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Inventory>> GetInventory()
        {
            return await _services.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>> GetInventory(int id)
        {
            return await _services.Get(id);
        }

        //// PUT: api/Questions/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventory(int id, Inventory inventory)
        {
            if (id != inventory.Id)
            {
                return BadRequest();
            }
            await _services.Update(inventory);
            return NoContent();
        }

        //// POST: api/Questions
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inventory>> PostInventory(Inventory inventory)
        {
            var newInt = await _services.Create(inventory);
            return CreatedAtAction(nameof(GetInventory), new { id = newInt.Id }, newInt);

        }

        //// DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            var inventory = await _services.Get(id);
            if (inventory == null)
            {
                return NotFound();
            }
            await _services.Delete(id);
            return NoContent();
        }
    }
}
