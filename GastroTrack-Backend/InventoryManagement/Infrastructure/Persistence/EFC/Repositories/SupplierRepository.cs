using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Entities;
using chefstock_platform.InventoryManagement.Domain.Repositories;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace chefstock_platform.InventoryManagement.Infrastructure.Persistence.EFC.Repositories;

public class SupplierRepository(AppDbContext context) : BaseRepository<Supplier>(context), ISupplierRepository
{
    public async Task<Supplier?> GetByIdAsync(int supplierId)
    {
        return await Context.Set<Supplier>().FindAsync(supplierId);
    }

    public async Task UpdateAsync(Supplier supplier)
    {
        Context.Set<Supplier>().Update(supplier);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int supplierId)
    {
        var supplier = await Context.Set<Supplier>().FindAsync(supplierId);
        if (supplier != null)
        {
            Context.Set<Supplier>().Remove(supplier);
            await Context.SaveChangesAsync();
        }
    }
}