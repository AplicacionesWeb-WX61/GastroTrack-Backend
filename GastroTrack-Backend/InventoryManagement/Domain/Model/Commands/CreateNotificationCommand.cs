﻿namespace chefstock_platform.InventoryManagement.Domain.Model.Commands;

public record CreateNotificationCommand(string NotificationName,string? NotificationDescription);