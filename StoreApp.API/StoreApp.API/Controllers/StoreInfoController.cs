using Microsoft.AspNetCore.Mvc;
using StoreApp.DataInfrastructure;
using System.ComponentModel.DataAnnotations;

namespace StoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreInfoController : ControllerBase
    {
        private readonly IRepository _repository;
        public StoreInfoController(IRepository repository)
        {
             _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Location> GetLocations() {
            return _repository.GetLocation().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<StoreInventory>> GetStoreProducts([Required] int id)
        {
            return _repository.GetStoreProducts(id).ToList();
        }
    }
}
