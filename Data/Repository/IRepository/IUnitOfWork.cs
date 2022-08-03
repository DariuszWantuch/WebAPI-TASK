namespace WebAPI.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICatalogRepository Catalog { get; }
        IProductRepository Product { get; }
    }
}
