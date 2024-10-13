using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Entities;
using chefstock_platform.Shared.Domain.Repositories;

namespace chefstock_platform.InventoryManagement.Domain.Repositories;

public interface ITaskRepository : IBaseRepository<Tasks>
{
    Task<Tasks?> GetByIdAsync(int tasksId);
    Task UpdateAsync(Tasks tasks);
    Task DeleteAsync(int id);
}