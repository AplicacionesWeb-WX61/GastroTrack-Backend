using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;

namespace chefstock_platform.InventoryManagement.Interfaces.ACL.Services;

public interface ITaskContextFacade
{
    Task<int> CreateTask(string taskName, string taskDescription,string taskDate);
    Task<Tasks?> FetchTaskById(int supplierId);
    Task<IEnumerable<Tasks>> FetchAllTask();
    Task UpdateTask(int taskId, string taskName, string taskDescription,string taskDate);
    Task DeleteTask(int taskId);
}