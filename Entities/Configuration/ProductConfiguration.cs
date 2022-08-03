using WebAPI.Data.Repository.IRepository;
using WebAPI.Entities.Models;

namespace WebAPI.Entities.Configuration
{
    public class ProductConfiguration
    {
        public void Initialize(IUnitOfWork unitOfWork)
        {
            unitOfWork.Product.Add(new Product { Code = "NOKIA64GB", Name = "Smartphone Nokia 64GB", Price = 699.99M, CatalogId = 1});
            unitOfWork.Product.Add(new Product { Code = "OPPO64GB", Name = "Smartphone Oppo 64GB", Price = 799.99M, CatalogId = 1 });
            unitOfWork.Product.Add(new Product { Code = "NOKIA128GB", Name = "Smartphone Nokia 128GB", Price = 999.99M, CatalogId = 2 });
            unitOfWork.Product.Add(new Product { Code = "OPPO128GB", Name = "Smartphone Oppo 128GB", Price = 1199.99M, CatalogId = 2 });

            unitOfWork.Product.Add(new Product { Code = "TVSAMSUNG55", Name = "Telewizor Samsung 55", Price = 1699.99M, CatalogId = 3 });
            unitOfWork.Product.Add(new Product { Code = "TVLG55", Name = "Telewizor LG 55", Price = 2699.99M, CatalogId = 3 });
            unitOfWork.Product.Add(new Product { Code = "TVSAMSUNG49", Name = "Telewizor Samsung 55", Price = 1499.99M, CatalogId = 4 });
            unitOfWork.Product.Add(new Product { Code = "TVLG49", Name = "Telewizor LG 55", Price = 2499.99M, CatalogId = 4 });
        }
    }
}
