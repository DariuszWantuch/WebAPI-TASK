using WebAPI.Data.Repository.IRepository;

namespace WebAPI.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Catalog = new CatalogRepository(_context);
            Product = new ProductRepository(_context);

        }

        public ICatalogRepository Catalog { get; private set; }
        public IProductRepository Product { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
