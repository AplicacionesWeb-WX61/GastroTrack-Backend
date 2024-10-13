using chefstock_platform.InventoryManagement.Domain.Model.Commands;
using chefstock_platform.InventoryManagement.Interfaces.REST.Resources;

namespace chefstock_platform.InventoryManagement.Interfaces.REST.Transform;

public static class UpdateTaskCommandFromResourceAssembler
{
    public static UpdateTaskCommand ToCommandFromResource(UpdateTaskResource resource)
    {
        return new UpdateTaskCommand(resource.TaskId, resource.TaskName, resource.TaskDescription, resource.TaskDate);
    }
}