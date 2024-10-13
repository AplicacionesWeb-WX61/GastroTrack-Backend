using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Commands;

namespace chefstock_platform.InventoryManagement.Domain.Services;

public interface ITaskCommandService
{
    Task<Tasks?> Handle(CreateTaskCommand command);
    Task<Tasks?> Handle(UpdateTaskCommand command);
    Task Handle(DeleteTaskCommand command);
}