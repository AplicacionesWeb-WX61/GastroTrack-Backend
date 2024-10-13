using chefstock_platform.InventoryManagement.Domain.Model.Commands;
using chefstock_platform.InventoryManagement.Interfaces.REST.Resources;

namespace chefstock_platform.InventoryManagement.Interfaces.REST.Transform;

public static class UpdateNotificationCommandFromResourceAssembler
{
    public static UpdateNotificationCommand ToCommandFromResource(UpdateNotificationResource resource)
    {
        return new UpdateNotificationCommand(resource.NotificationId, resource.NotificationName, resource.NotificationDescription);
    }
}