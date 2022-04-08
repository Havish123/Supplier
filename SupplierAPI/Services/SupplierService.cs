using Microsoft.EntityFrameworkCore;
using SupplierAPI.Data;
using SupplierAPI.Models;

namespace SupplierAPI.Services
{
    public interface ISupplierService
    {
        public Task<Supplier> Get(int id);
        public Task<Supplier> Create(Supplier supplier);
        public Task Delete(int id);
        public Task<IEnumerable<Supplier>> Get();
        public Task Update(Supplier supplier);

    }
    public class SupplierService : ISupplierService
    {
        private readonly SupplierDBContext _context;
        public SupplierService(SupplierDBContext context)
        {
            _context = context;
        }
        public async Task<Supplier> Create(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task Delete(int id)
        {
            var supplier = await _context.Products.FindAsync(id);
            if (supplier != null)
            {
                _context.Products.Remove(supplier);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Supplier> Get(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier != null)
            {
                return supplier;
            }
            return null;
        }

        public async Task<IEnumerable<Supplier>> Get()
        {
            return await _context.Suppliers.ToListAsync();

        }

        public async Task Update(Supplier supplier)
        {
            _context.Entry(supplier).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}