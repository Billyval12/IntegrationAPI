using Microsoft.EntityFrameworkCore;
using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
using RSMEnterpriseIntegrationsAPI.Domain.Models;


namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AdvWorksDbContext _context;

        public ProductCategoryRepository(AdvWorksDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateProductCategory(ProductCategory productCategory)
        {
            await _context.AddAsync(productCategory);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteProductCategory(int id)
        {
            var productCategory = await GetProductCategoryById(id);
            if (productCategory != null)
            {
                _context.Remove(productCategory);
                return await _context.SaveChangesAsync();
            }
            return 0; // Opcional: Puedes manejar el caso en que la categoría no se encuentre en la base de datos
        }

        public async Task<IEnumerable<ProductCategory>> GetAllProductCategories()
        {
            return await _context.Set<ProductCategory>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ProductCategory?> GetProductCategoryById(int id)
        {
            return await _context.ProductCategories
                .AsNoTracking()
                .FirstOrDefaultAsync(pc => pc.ProductCategoryId == id);
        }

        public async Task<int> UpdateProductCategory(ProductCategory productCategory)
        {
            _context.Update(productCategory);
            return await _context.SaveChangesAsync();
        }
    }
}
