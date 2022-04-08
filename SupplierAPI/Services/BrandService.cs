using Microsoft.EntityFrameworkCore;
using SupplierAPI.Data;
using SupplierAPI.Models;

namespace SupplierAPI.Services
{
    public interface IBrandService
    {
        public Task<Brand> Get(int id);
        public Task<Brand> Create(Brand brand);
        public Task Delete(int id);
        public Task<IEnumerable<Brand>> Get();
        public Task Update(Brand brand);



    }
    public class BrandService : IBrandService
    {
        private readonly SupplierDBContext _context;
        public BrandService(SupplierDBContext context)
        {
            _context = context;
        }
        public async Task<Brand> Create(Brand brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task Delete(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand != null)
            {
                _context.Brands.Remove(brand);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Brand> Get(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand != null)
            {
                return brand;
            }
            return null;
        }

        public async Task<IEnumerable<Brand>> Get()
        {
            return await _context.Brands.ToListAsync();

        }

        public async Task Update(Brand brand)
        {
            _context.Entry(brand).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
