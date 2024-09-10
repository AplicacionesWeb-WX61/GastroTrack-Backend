using chefstock_platform.InventoryManagement.Domain.Model.Entities;
using chefstock_platform.InventoryManagement.Interfaces.REST.Resources;

namespace chefstock_platform.InventoryManagement.Interfaces.REST.Transform;

public static class SupplierResourceFromEntityAssembler
{
    public static SupplierResource ToResourceFromEntity(Supplier entity)
    {
        return new SupplierResource(entity.SupplierId, entity.SupplierName, entity.ContactName, entity.ContactEmail, entity.Phone, entity.Address);
    }
}