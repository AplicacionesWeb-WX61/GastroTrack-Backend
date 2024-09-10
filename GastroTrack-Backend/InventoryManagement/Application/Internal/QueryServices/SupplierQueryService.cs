using chefstock_platform.InventoryManagement.Domain.Model.Queries;
using chefstock_platform.InventoryManagement.Domain.Repositories;
using chefstock_platform.InventoryManagement.Domain.Services;
using chefstock_platform.InventoryManagement.Domain.Model.Entities;

namespace chefstock_platform.InventoryManagement.Application.Internal.QueryServices;

public class SupplierQueryService(ISupplierRepository supplierRepository) : ISupplierQueryService
{
    public async Task<IEnumerable<Supplier>> Handle(GetAllSuppliersQuery query)
    {
        return await supplierRepository.ListAsync();
    }

    public async Task<Supplier?> Handle(GetSupplierByIdQuery query)
    {
        return await supplierRepository.FindByIdAsync(query.SupplierId);
    }
}