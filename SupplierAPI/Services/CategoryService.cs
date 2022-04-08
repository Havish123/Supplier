using Microsoft.EntityFrameworkCore;
using SupplierAPI.Data;
using SupplierAPI.Models;

namespace SupplierAPI.Services
{
    public interface ICategoryService
    {
        public Task<Category> Get(int id);
        public Task<Category> Create(Category category);
        public Task Delete(int id);
        public Task<IEnumerable<Category>> Get();
        public Task Update(Category category);



    }
    public class CategoryService : ICategoryService
    {
        private readonly SupplierDBContext _context;
        public CategoryService(SupplierDBContext context)
        {
            _context = context;
        }
        public async Task<Category> Create(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Category> Get(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                return category;
            }
            return null;
        }

        public async Task<IEnumerable<Category>> Get()
        {
            return await _context.Categories.ToListAsync();

        }

        public async Task Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
