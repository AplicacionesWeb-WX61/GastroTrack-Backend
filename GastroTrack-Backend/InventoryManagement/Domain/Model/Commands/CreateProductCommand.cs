namespace chefstock_platform.InventoryManagement.Domain.Model.Commands;

public record CreateProductCommand(string Name, int CategoryId, string DateManufacture, string DueDate, int Stock, string State, string Image);
