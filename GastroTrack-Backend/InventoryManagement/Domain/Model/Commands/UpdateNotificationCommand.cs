﻿namespace chefstock_platform.InventoryManagement.Domain.Model.Commands;

public record UpdateNotificationCommand(int NotificationId,string NotificationName,string? NotificationDescription);