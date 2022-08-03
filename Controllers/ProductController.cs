using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.Repository.IRepository;
using WebAPI.Entities.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var productList = await _unitOfWork.Product.GetAll();

            return productList.ToList();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Product product)
        {
            await _unitOfWork.Product.Add(product);

            return Ok();
        }
    }
}
