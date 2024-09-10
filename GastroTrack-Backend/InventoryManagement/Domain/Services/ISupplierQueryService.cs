using chefstock_platform.InventoryManagement.Domain.Model.Entities;
using chefstock_platform.InventoryManagement.Domain.Model.Queries;

namespace chefstock_platform.InventoryManagement.Domain.Services;

public interface ISupplierQueryService
{
    Task<IEnumerable<Supplier>> Handle(GetAllSuppliersQuery query);
    Task<Supplier?> Handle(GetSupplierByIdQuery query);
}