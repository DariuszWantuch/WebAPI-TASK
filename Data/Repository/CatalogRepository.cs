using WebAPI.Data.Repository.IRepository;
using WebAPI.Entities.Models;

namespace WebAPI.Data.Repository
{
    public class CatalogRepository : Repository<Catalog>, ICatalogRepository
    {
        private readonly ApplicationDbContext _context;

        public CatalogRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
