using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Commands;
using chefstock_platform.InventoryManagement.Domain.Repositories;
using chefstock_platform.InventoryManagement.Domain.Services;
using chefstock_platform.Shared.Domain.Repositories;

namespace chefstock_platform.InventoryManagement.Application.Internal.CommandServices;

public class NotificationCommandService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork) : INotificationCommandService
{
    public async Task<Notification?> Handle(CreateNotificationCommand command) 
    {
        var notification = new Notification(command);
        try
        {
            await notificationRepository.AddAsync(notification);
            await unitOfWork.CompleteAsync();
            return notification;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the product: {e.Message}");
            throw;
        }
    }
    
    public async Task<Notification?> Handle(UpdateNotificationCommand command)
    {
        var notification = await notificationRepository.GetByIdAsync(command.NotificationId);
        if (notification != null)
        {
            notification.Update(command);
            await notificationRepository.UpdateAsync(notification);
            await unitOfWork.CompleteAsync();
            return notification;
        }
        else
        {
            Console.WriteLine($"Product with id {command.NotificationId} not found");
            throw new Exception($"Product with id {command.NotificationId} not found");
        }
    }
    
    public async Task Handle(DeleteNotificationCommand command)
    {
        var notification = await notificationRepository.GetByIdAsync(command.NotificationId);
        if (notification != null)
        {
            await notificationRepository.DeleteAsync(notification.NotificationId);
            await unitOfWork.CompleteAsync();
        }
        else
        {
            Console.WriteLine($"Product with id {command.NotificationId} not found");
            throw new Exception($"Product with id {command.NotificationId} not found"); 
        }
    }
}