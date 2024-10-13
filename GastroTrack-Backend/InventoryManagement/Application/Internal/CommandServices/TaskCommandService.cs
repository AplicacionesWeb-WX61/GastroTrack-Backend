using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Commands;
using chefstock_platform.InventoryManagement.Domain.Repositories;
using chefstock_platform.InventoryManagement.Domain.Services;
using chefstock_platform.Shared.Domain.Repositories;

namespace chefstock_platform.InventoryManagement.Application.Internal.CommandServices;

public class TaskCommandService(ITaskRepository taskRepository, IUnitOfWork unitOfWork) : ITaskCommandService
{
    public async Task<Tasks?> Handle(CreateTaskCommand command)
            {
                var product = new Tasks(command);
                try
                {
                    await taskRepository.AddAsync(product);
                    await unitOfWork.CompleteAsync();
                    return product;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An error occurred while creating the product: {e.Message}");
                    throw;
                }
            }
    
            public async Task<Tasks?> Handle(UpdateTaskCommand command)
            {
                var task = await taskRepository.GetByIdAsync(command.TaskId);
                if (task != null)
                {
                    task.Update(command);
                    await taskRepository.UpdateAsync(task);
                    await unitOfWork.CompleteAsync();
                    return task;
                }
                else
                {
                    Console.WriteLine($"Product with id {command.TaskId} not found");
                    throw new Exception($"Product with id {command.TaskId} not found");
                }
            }
    
            public async Task Handle(DeleteTaskCommand command)
            {
                var task = await taskRepository.GetByIdAsync(command.TaskId);
                if (task != null)
                {
                    await taskRepository.DeleteAsync(task.TaskId);
                    await unitOfWork.CompleteAsync();
                }
                else
                {
                    Console.WriteLine($"Product with id {command.TaskId} not found");
                    throw new Exception($"Product with id {command.TaskId} not found");
                }
            }
}