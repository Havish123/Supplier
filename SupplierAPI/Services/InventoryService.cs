using Microsoft.EntityFrameworkCore;
using SupplierAPI.Data;
using SupplierAPI.Models;

namespace SupplierAPI.Services
{
    public interface IInventoryService
    {
        public Task<Inventory> Get(int id);
        public Task<Inventory> Create(Inventory inventory);
        public Task Delete(int id);
        public Task<IEnumerable<Inventory>> Get();
        public Task Update(Inventory inventory);



    }
    public class InventoryService : IInventoryService
    {
        private readonly SupplierDBContext _context;
        public InventoryService(SupplierDBContext context)
        {
            _context = context;
        }
        public async Task<Inventory> Create(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();
            return inventory;
        }

        public async Task Delete(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory != null)
            {
                _context.Inventories.Remove(inventory);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Inventory> Get(int id)
        {
            var produt= await _context.Products.FindAsync(id);
            var inventory = _context.Inventories.First(m => m.ProductId==produt.Id);
            if(inventory != null)
            {
                return inventory;
            }
            return null;
        }

        public async Task<IEnumerable<Inventory>> Get()
        {
            var inventories=await _context.Inventories.ToListAsync();

            return inventories;

        }

        public async Task Update(Inventory inventory)
        {
            _context.Entry(inventory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
