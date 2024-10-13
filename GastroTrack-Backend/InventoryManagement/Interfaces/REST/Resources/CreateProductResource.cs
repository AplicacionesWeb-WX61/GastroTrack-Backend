namespace chefstock_platform.InventoryManagement.Interfaces.REST.Resources;

public record CreateProductResource(string Name, int CategoryId, string DateManufacture, string DueDate, int Stock, string State, string Image);
