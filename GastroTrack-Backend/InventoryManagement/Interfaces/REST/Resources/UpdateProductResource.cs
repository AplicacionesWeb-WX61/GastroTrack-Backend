namespace chefstock_platform.InventoryManagement.Interfaces.REST.Resources;

public record UpdateProductResource(int ProductId, string Name, int Stock, string Image, string Description, DateTime DueDate, int CategoryId);