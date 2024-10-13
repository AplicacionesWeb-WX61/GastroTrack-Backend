using chefstock_platform.InventoryManagement.Domain.Model.Commands;
using chefstock_platform.InventoryManagement.Interfaces.REST.Resources;

namespace chefstock_platform.InventoryManagement.Interfaces.REST.Transform;

public static class CreateTaskCommandFromResourceAssembler
{
    public static CreateTaskCommand ToCommandFromResource(CreateTaskResource resource)
    {
        return new CreateTaskCommand(resource.TaskName, resource.TaskDescription, resource.TaskDate);
    }
}