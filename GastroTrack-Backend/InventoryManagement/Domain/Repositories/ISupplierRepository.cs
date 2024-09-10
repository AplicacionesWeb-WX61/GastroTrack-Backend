using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Entities;
using chefstock_platform.Shared.Domain.Repositories;

namespace chefstock_platform.InventoryManagement.Domain.Repositories;

public interface ISupplierRepository : IBaseRepository<Supplier>
{
    Task<Supplier?> GetByIdAsync(int supplierId);
    Task UpdateAsync(Supplier supplier);
    Task DeleteAsync(int id);
}