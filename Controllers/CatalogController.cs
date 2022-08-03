using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.Repository.IRepository;
using WebAPI.Entities.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CatalogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catalog>>> GetAll()
        {
            var catalogList =  await _unitOfWork.Catalog.GetAll();

            return catalogList.ToList();
        }      

        [HttpPost]
        public async Task<ActionResult> Post(Catalog catalog)
        {
            await _unitOfWork.Catalog.Add(catalog);

            return Ok();
        }
    }
}
