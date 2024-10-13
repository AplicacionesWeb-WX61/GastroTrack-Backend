using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Commands;

namespace chefstock_platform.InventoryManagement.Domain.Services;

public interface INotificationCommandService
{
    Task<Notification?> Handle(CreateNotificationCommand command);
    Task<Notification?> Handle(UpdateNotificationCommand command);
    Task Handle(DeleteNotificationCommand command);
}