using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Repositories;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace chefstock_platform.InventoryManagement.Infrastructure.Persistence.EFC.Repositories;

public class TaskRepository(AppDbContext context) : BaseRepository<Tasks>(context), ITaskRepository
{
    public async Task<Tasks?> GetByIdAsync(int tasksId)
    {
        return await Context.Set<Tasks>().FindAsync(tasksId);
    }

    public async Task UpdateAsync(Tasks tasks)
    {
        Context.Set<Tasks>().Update(tasks);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int tasksId)
    {
        var tasks = await Context.Set<Tasks>().FindAsync(tasksId);
        if (tasks != null)
        {
            Context.Set<Tasks>().Remove(tasks);
            await Context.SaveChangesAsync();
        }
    }
}