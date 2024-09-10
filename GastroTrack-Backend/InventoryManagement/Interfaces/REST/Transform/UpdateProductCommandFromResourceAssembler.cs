using chefstock_platform.InventoryManagement.Domain.Model.Commands;
using chefstock_platform.InventoryManagement.Interfaces.REST.Resources;

namespace chefstock_platform.InventoryManagement.Interfaces.REST.Transform;

public static class UpdateProductCommandFromResourceAssembler
{
    public static UpdateProductCommand ToCommandFromResource(UpdateProductResource resource)
    {
        return new UpdateProductCommand(resource.ProductId, resource.Name, resource.Stock, resource.Image, resource.Description, resource.DueDate, resource.CategoryId);
    }
}