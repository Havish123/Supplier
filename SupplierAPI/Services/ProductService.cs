using Microsoft.EntityFrameworkCore;
using SupplierAPI.Data;
using SupplierAPI.Models;

namespace SupplierAPI.Services
{
    public interface IProductService
    {
        public Task<Product> Get(int id);
        public Task<Product> Create(Product product);
        public Task Delete(int id);
        public Task<IEnumerable<Product>> Get();
        public Task Update(Product product);

    }
    public class ProductService : IProductService
    {
        private readonly SupplierDBContext _context;
        public ProductService(SupplierDBContext context)
        {
            _context = context;
        }
        public async Task<Product> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Product> Get(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                return product;
            }
            return null;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await _context.Products.ToListAsync();
           
        }

        public async Task Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
