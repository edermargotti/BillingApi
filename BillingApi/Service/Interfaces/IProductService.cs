using BillingApi.Domain.Models;
using BillingApi.ViewModels;

namespace BillingApi.Service.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product?> GetProduct(int idProduct);
        Task<int?> PostProduct(ProductViewModel product);
        Task PutProduct(ProductViewModel product);
        Task DeleteProduct(int id);
    }
}
