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
        //private readonly StudentDBContext _context;
        //public StudentService(StudentDBContext context)
        //{
        //    _context = context;
        //}
        //public async Task<Student> Create(Student student)
        //{
        //    _context.Students.Add(student);
        //    await _context.SaveChangesAsync();
        //    return student;
        //}

        //public async Task Delete(int id)
        //{
        //    var student = await _context.Students.FindAsync(id);
        //    if (student != null)
        //    {
        //        _context.Students.Remove(student);
        //        await _context.SaveChangesAsync();
        //    }

        //}

        //public async Task<Student> Get(int id)
        //{
        //    var student = await _context.Students.FindAsync(id);
        //    if (student != null)
        //    {
        //        return student;
        //    }
        //    return null;
        //}

        //public async Task<IEnumerable<Student>> Get()
        //{
        //    return await _context.Students.ToListAsync();
        //}

        //public async Task Update(Student student)
        //{
        //    _context.Entry(student).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //}
        public Task<Product> Create(Product product)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> Get()
        {
            throw new NotImplementedException();
        }

        public Task Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
