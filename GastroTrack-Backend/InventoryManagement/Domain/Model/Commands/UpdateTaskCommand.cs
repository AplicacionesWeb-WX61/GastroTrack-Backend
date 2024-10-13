namespace chefstock_platform.InventoryManagement.Domain.Model.Commands;

public record UpdateTaskCommand(int TaskId,string TaskName, string TaskDescription, string TaskDate);