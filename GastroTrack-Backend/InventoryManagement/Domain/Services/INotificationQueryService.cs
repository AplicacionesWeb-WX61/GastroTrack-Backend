using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Queries;

namespace chefstock_platform.InventoryManagement.Domain.Services;

public interface INotificationQueryService
{
    Task<IEnumerable<Notification>> Handle(GetAllNotificationQuery query);
    Task<Notification?> Handle(GetNotificationByIdQuery query);
}