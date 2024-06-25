using BillingApi.Domain.Models;
using BillingApi.Infra;
using BillingApi.Service.Interfaces;
using BillingApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BillingApi.Service.Services
{
    public class ProductService(DataContext context,
                                IUtilsService utilsService) : IProductService
    {
        private readonly DataContext _context = context;
        private readonly IUtilsService _utilsService = utilsService;

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product?> GetProduct(int idProduct)
        {
            return await _context.Product.FindAsync(idProduct);
        }

        public async Task<int?> PostProduct(ProductViewModel product)
        {
            try
            {
                var productEntity = _utilsService.ConvertToEntity<Product, ProductViewModel>(product);

                _context.Product.Add(productEntity);
                await _context.SaveChangesAsync();

                return productEntity.Id;
            }
            catch (Exception ex)
            {
                _context.Rollback();
                throw new Exception($"Erro ao inserir o product: {ex.Message}");
            }

        }

        public async Task PutProduct(ProductViewModel product)
        {
            try
            {
                var productEntity = _utilsService.ConvertToEntity<Product, ProductViewModel>(product);

                _context.Entry(productEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _context.Rollback();
                throw new Exception($"Erro ao atualizar o product: {ex.Message}");
            }

        }

        public async Task DeleteProduct(int id)
        {
            try
            {
                var product = await GetProduct(id);
                if (product == null)
                    throw new KeyNotFoundException($"Registro {id} não encontrado.");

                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _context.Rollback();
                throw new Exception($"Erro ao deletar o product: {ex.Message}");
            }

        }
    }
}
