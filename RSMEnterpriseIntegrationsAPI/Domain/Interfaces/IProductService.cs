using RSMEnterpriseIntegrationsAPI.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
    public interface IProductService
    {
        Task<GetProductDto?> GetProductById(int id);
        Task<IEnumerable<GetProductDto>> GetAll();
        Task<int> CreateProduct(CreateProductDto productDto);
        Task<int> UpdateProduct(UpdateProductDto productDto);
        Task<int> DeleteProduct(int id);
    }
}
