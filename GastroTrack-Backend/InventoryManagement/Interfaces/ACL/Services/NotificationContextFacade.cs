using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Commands;
using chefstock_platform.InventoryManagement.Domain.Model.Queries;
using chefstock_platform.InventoryManagement.Domain.Services;

namespace chefstock_platform.InventoryManagement.Interfaces.ACL.Services;

public class NotificationContextFacade(
    INotificationCommandService notificationCommandService,
    INotificationQueryService notificationQueryService)
    : INotificationContextFacade
{
    public async Task<int> CreateNotification(string notificationName,string notificationDescription)
    {
        var createNotificationCommand = new CreateNotificationCommand(notificationName,notificationDescription);
        var notification = await notificationCommandService.Handle(createNotificationCommand);
        return notification?.NotificationId ?? 0;
    }

    public async Task<Notification?> FetchNotificationById(int id)
    {
        var getNotificationByIdQuery = new GetNotificationByIdQuery(id);
        return await notificationQueryService.Handle(getNotificationByIdQuery);
    }

    public async Task<IEnumerable<Notification>> FetchAllNotification()
    {
        var getAllNotificationQuery = new GetAllNotificationQuery();
        return await notificationQueryService.Handle(getAllNotificationQuery);
    }

    public async Task UpdateNotification(int id,string notificationName,string notificationDescription)
    {
        var updateNotificationCommand = new UpdateNotificationCommand(id,notificationName,notificationDescription);
        await notificationCommandService.Handle(updateNotificationCommand);
    }

    public async Task DeleteNotification(int id)
    {
        var deleteNotificationCommand = new DeleteNotificationCommand(id);
        await notificationCommandService.Handle(deleteNotificationCommand);
    }
}