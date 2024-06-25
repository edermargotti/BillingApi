using BillingApi.Domain.Models;
using BillingApi.Infra;
using BillingApi.Service.Interfaces;
using BillingApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BillingApi.Service.Services
{
    public class CustomerService(DataContext context,
                                 IUtilsService utilsService) : ICustomerService
    {
        private readonly DataContext _context = context;
        private readonly IUtilsService _utilsService = utilsService;

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task<Customer?> GetCustomer(int idCustomer)
        {
            return await _context.Customer.FindAsync(idCustomer);
        }

        public async Task<int?> PostCustomer(CustomerViewModel customer)
        {
            try
            {
                var customerEntity = _utilsService.ConvertToEntity<Customer, CustomerViewModel>(customer);

                _context.Customer.Add(customerEntity);
                await _context.SaveChangesAsync();

                return customerEntity.Id;
            }
            catch (Exception ex)
            {
                _context.Rollback();
                throw new Exception($"Erro ao inserir o customer: {ex.Message}");
            }
            
        }

        public async Task PutCustomer(CustomerViewModel customer)
        {
            try
            {
                var customerEntity = _utilsService.ConvertToEntity<Customer, CustomerViewModel>(customer);

                _context.Entry(customerEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _context.Rollback();
                throw new Exception($"Erro ao atualizar o customer: {ex.Message}");
            }

        }

        public async Task DeleteCustomer(int id)
        {
            try
            {
                var customer = await GetCustomer(id);
                if (customer == null)
                    throw new KeyNotFoundException($"Registro {id} não encontrado.");

                _context.Customer.Remove(customer);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _context.Rollback();
                throw new Exception($"Erro ao deletar o customer: {ex.Message}");
            }

        }

        
    }

}
