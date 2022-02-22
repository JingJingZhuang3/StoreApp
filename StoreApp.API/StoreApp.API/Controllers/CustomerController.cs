using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StoreApp.API.Dtos;
using StoreApp.DataInfrastructure;

namespace StoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository _repository;

        public CustomerController(IRepository repository)
        {
           _repository = repository;   
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateAccount([FromBody] CustomerName customerName)
        {
            Customer customer = await _repository.AddNewCustomerAsync(customerName.firstName!, customerName.lastName!);
   
            return customer;
        }
    }
}
