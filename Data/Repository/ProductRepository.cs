using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Repository.IRepository;
using WebAPI.Entities.Models;

namespace WebAPI.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Set<Product>().Include(x => x.Catalog).ToListAsync();
        }
    }
}
