using RSMEnterpriseIntegrationsAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetProductById(int id);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<int> CreateProduct(Product product);
        Task<int> UpdateProduct(Product product);
        Task<int> DeleteProduct(Product product);
    }
}
