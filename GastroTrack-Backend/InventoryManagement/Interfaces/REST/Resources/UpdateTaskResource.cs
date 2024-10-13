namespace chefstock_platform.InventoryManagement.Interfaces.REST.Resources;

public record UpdateTaskResource(int TaskId,string TaskName, string TaskDescription, string TaskDate);