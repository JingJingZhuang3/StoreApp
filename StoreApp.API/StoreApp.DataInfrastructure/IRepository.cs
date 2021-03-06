namespace StoreApp.DataInfrastructure
{
    public interface IRepository
    {
        Task<Customer> AddNewCustomerAsync(string firstname, string lastname);
        Customer? GetCustomer(string firstname, string lastname);
        IEnumerable<Location> GetLocation();
        IEnumerable<StoreInventory> GetStoreProducts(int id);
    }
}