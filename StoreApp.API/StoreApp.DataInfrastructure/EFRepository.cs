using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace StoreApp.DataInfrastructure
{
    public class EFRepository:IRepository
    {
        private readonly StoreAppContext _context;
        private readonly ILogger<EFRepository> _logger;

        public EFRepository(StoreAppContext context, ILogger<EFRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Customer? GetCustomer(string firstname, string lastname)
        {
            var customer = _context.Customers.SingleOrDefault(cus => cus.FirstName == firstname && cus.LastName == lastname);
            if (customer != null)
            {
                return customer;
            }
            return null;
        }

        public async Task<Customer> AddNewCustomerAsync(string firstname, string lastname)
        {
            var customer = GetCustomer(firstname, lastname);
            if(customer != null)
            {
                return customer;
            }
            else
            {
                var newCustomer = new Customer { FirstName = firstname, LastName = lastname };
                await _context.AddAsync(newCustomer);
                await _context.SaveChangesAsync();
                return GetCustomer(firstname,lastname)!;
            }
        }

        public IEnumerable<Location> GetLocation()
        {
            return _context.Locations.ToList();
        }

        public IEnumerable<StoreInventory> GetStoreProducts(int id)
        {
            return _context.StoreInventories.Where(store => store.LocationId == id).ToList();
        }
    }
}