using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Commands;
using chefstock_platform.InventoryManagement.Domain.Model.Queries;
using chefstock_platform.InventoryManagement.Domain.Services;

namespace chefstock_platform.InventoryManagement.Interfaces.ACL.Services;

public class TaskContextFacade(
    ITaskCommandService taskCommandService,
    ITaskQueryService taskQueryService)
    : ITaskContextFacade
{
    public async Task<int> CreateTask(string taskName, string taskDescription,string taskDate)
    {
        var createTaskCommand = new CreateTaskCommand(taskName, taskDescription,taskDate);
        var tasks = await taskCommandService.Handle(createTaskCommand);
        return tasks?.TaskId ?? 0;
    }

    public async Task<Tasks?> FetchTaskById(int id)
    {
        var getTaskByIdQuery = new GetTasksByIdQuery(id);
        return await taskQueryService.Handle(getTaskByIdQuery);
    }

    public async Task<IEnumerable<Tasks>> FetchAllTask()
    {
        var getAllTaskQuery = new GetAllTasksQuery();
        return await taskQueryService.Handle(getAllTaskQuery);
    }

    public async Task UpdateTask(int id, string taskName, string taskDescription,string taskDate)
    {
        var updateTaskCommand = new UpdateTaskCommand(id, taskName, taskDescription,taskDate);
        await taskCommandService.Handle(updateTaskCommand);
    }

    public async Task DeleteTask(int id)
    {
        var deleteTaskCommand = new DeleteTaskCommand(id);
        await taskCommandService.Handle(deleteTaskCommand);
    }
}