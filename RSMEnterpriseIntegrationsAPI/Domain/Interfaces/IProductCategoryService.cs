using RSMEnterpriseIntegrationsAPI.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
    public interface IProductCategoryService
    {
        Task<GetProductCategoryDto?> GetProductCategoryById(int id);
        Task<IEnumerable<GetProductCategoryDto>> GetAll();
        Task<int> CreateProductCategory(CreateProductCategoryDto productCategoryDto);
        Task<int> UpdateProductCategory(UpdateProductCategoryDto productCategoryDto);
        Task<int> DeleteProductCategory(int id);
    }
}
