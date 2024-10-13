using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Queries;
using chefstock_platform.InventoryManagement.Domain.Repositories;
using chefstock_platform.InventoryManagement.Domain.Services;

namespace chefstock_platform.InventoryManagement.Application.Internal.QueryServices;

public class TaskQueryService(ITaskRepository taskRepository) : ITaskQueryService
{
    public async Task<IEnumerable<Tasks>> Handle(GetAllTasksQuery query)
    {
        return await taskRepository.ListAsync();
    }

    public async Task<Tasks?> Handle(GetTasksByIdQuery query)
    {
        return await taskRepository.FindByIdAsync(query.TaskId);
    }
}