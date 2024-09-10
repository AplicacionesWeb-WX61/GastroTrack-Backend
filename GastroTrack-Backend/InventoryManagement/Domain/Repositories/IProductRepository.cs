using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.Shared.Domain.Repositories;

namespace chefstock_platform.InventoryManagement.Domain.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<Product?> GetByIdAsync(int productId);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
}