using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.Shared.Domain.Repositories;

namespace chefstock_platform.InventoryManagement.Domain.Repositories;

public interface INotificationRepository: IBaseRepository<Notification>
{
    Task<Notification?> GetByIdAsync(int notificationId);
    Task UpdateAsync(Notification notification);
    Task DeleteAsync(int id);
}