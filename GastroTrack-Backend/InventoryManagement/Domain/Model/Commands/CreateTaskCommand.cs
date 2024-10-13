namespace chefstock_platform.InventoryManagement.Domain.Model.Commands;

public record CreateTaskCommand(string TaskName, string TaskDescription,string TaskDate);