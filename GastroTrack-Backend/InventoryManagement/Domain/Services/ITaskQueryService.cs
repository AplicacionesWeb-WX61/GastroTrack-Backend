using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Queries;

namespace chefstock_platform.InventoryManagement.Domain.Services;

public interface ITaskQueryService
{
    Task<IEnumerable<Tasks>> Handle(GetAllTasksQuery query);
    Task<Tasks?> Handle(GetTasksByIdQuery query);
}