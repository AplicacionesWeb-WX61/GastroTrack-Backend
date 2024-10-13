using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;

namespace chefstock_platform.InventoryManagement.Interfaces.ACL;

public interface INotificationContextFacade
{
    Task<int> CreateNotification(string notificationName,string notificationDescription);
    Task<Notification?> FetchNotificationById(int notificationId);
    Task<IEnumerable<Notification>> FetchAllNotification();
    Task UpdateNotification(int notificationId, string notificationName,string notificationDescription);
    Task DeleteNotification(int notificationId);
}