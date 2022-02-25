using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StoreApp.API.Dtos;
using StoreApp.DataInfrastructure;
using System.ComponentModel.DataAnnotations;

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
        public async Task<ActionResult<Customer>> CreateAccount([FromBody, Required] CustomerName customerName)
        {
            Customer customer = await _repository.AddNewCustomerAsync(customerName.firstName!, customerName.lastName!);
   
            return customer;
        }

        [HttpGet]
        public ActionResult<Customer> GetAccount([FromQuery, Required] string firstname, [Required]string lastname)
        {
            var customer = _repository.GetCustomer(firstname, lastname);
            if(customer == null)
            {
                return StatusCode(404);
            }
            return customer;
        }
    }
}
