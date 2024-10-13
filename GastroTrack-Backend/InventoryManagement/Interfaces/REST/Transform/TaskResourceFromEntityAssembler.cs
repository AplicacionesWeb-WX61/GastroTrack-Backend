using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Interfaces.REST.Resources;

namespace chefstock_platform.InventoryManagement.Interfaces.REST.Transform;

public static class TaskResourceFromEntityAssembler
{
    public static TaskResource ToResourceFromEntity(Tasks entity)
    {
        return new TaskResource(entity.TaskId, entity.TaskName, entity.TaskDescription, entity.TaskDate);
    }
}