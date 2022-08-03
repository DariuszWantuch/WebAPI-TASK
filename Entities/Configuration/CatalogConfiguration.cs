using WebAPI.Data.Repository.IRepository;
using WebAPI.Entities.Models;

namespace WebAPI.Entities.Configuration
{
    public class CatalogConfiguration
    {
        public void Initialize(IUnitOfWork unitOfWork)
        {
            unitOfWork.Catalog.Add(new Catalog { Name = "Smartphone 64GB" });
            unitOfWork.Catalog.Add(new Catalog { Name = "Smartphone 128GB" });

            unitOfWork.Catalog.Add(new Catalog { Name = "Smart TV 55" });
            unitOfWork.Catalog.Add(new Catalog { Name = "Smart TV 49" });
        }
    }
}
