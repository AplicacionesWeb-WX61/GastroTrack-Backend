using chefstock_platform.InventoryManagement.Domain.Model.Commands;
using chefstock_platform.InventoryManagement.Interfaces.REST.Resources;

namespace chefstock_platform.InventoryManagement.Interfaces.REST.Transform;

public static class UpdateSupplierCommandFromResourceAssembler
{
    public static UpdateSupplierCommand ToCommandFromResource(UpdateSupplierResource resource)
    {
        return new UpdateSupplierCommand(resource.SupplierId, resource.SupplierName, resource.ContactName, resource.ContactEmail, resource.Phone, resource.Address);
    }
}