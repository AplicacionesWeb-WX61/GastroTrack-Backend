namespace chefstock_platform.InventoryManagement.Domain.Model.Commands;

public record UpdateProductCommand(int ProductId, string Name, int CategoryId, string DateManufacture, string DueDate, int Stock, string State, string Image);
