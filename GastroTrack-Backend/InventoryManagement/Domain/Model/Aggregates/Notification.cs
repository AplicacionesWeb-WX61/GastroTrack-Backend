using chefstock_platform.InventoryManagement.Domain.Model.Commands;

namespace chefstock_platform.InventoryManagement.Domain.Model.Aggregates;

public class Notification
{
    public int NotificationId { get; set; }
    
    public string? NotificationName { get; set; }
    
    public string? NotificationDescription{ get; set; }
    
    public Notification()
    {
        
    }
    
    public Notification(int notificationId, string notificationName,string? notificationDescription)
    {
        NotificationId = notificationId;
        NotificationName = notificationName;
        NotificationDescription = notificationDescription;
    }

    
    public Notification(CreateNotificationCommand command)
    {
        NotificationName = command.NotificationName;
        NotificationDescription = command.NotificationDescription; 
    }

    // Método para actualizar el producto
    public void Update(UpdateNotificationCommand command)
    {
        NotificationId = command.NotificationId;
        NotificationName = command.NotificationName;
        NotificationDescription = command.NotificationDescription; 
    }
    
}