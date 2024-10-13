using chefstock_platform.InventoryManagement.Domain.Model.Commands;
using chefstock_platform.InventoryManagement.Interfaces.REST.Resources;

namespace chefstock_platform.InventoryManagement.Interfaces.REST.Transform;

public static class CreateSupplierCommandFromResourceAssembler
{
    public static CreateSupplierCommand ToCommandFromResource(CreateSupplierResource resource)
    {
        return new CreateSupplierCommand(resource.SupplierName, resource.RestaunrantName, resource.ContactEmail, resource.Phone, resource.SupplierName);
    }
}