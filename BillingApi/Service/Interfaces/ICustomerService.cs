using BillingApi.Domain.Models;
using BillingApi.ViewModels;

namespace BillingApi.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer?> GetCustomer(int idCustomer);
        Task<int?> PostCustomer(CustomerViewModel customer);
        Task PutCustomer(CustomerViewModel customer);
        Task DeleteCustomer(int id);
    }
}
