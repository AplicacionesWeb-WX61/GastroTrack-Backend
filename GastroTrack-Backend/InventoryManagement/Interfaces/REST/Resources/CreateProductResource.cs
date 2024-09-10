namespace chefstock_platform.InventoryManagement.Interfaces.REST.Resources;

public record CreateProductResource(string Name, int Stock, string Image, string Description, DateTime DueDate, int CategoryId);