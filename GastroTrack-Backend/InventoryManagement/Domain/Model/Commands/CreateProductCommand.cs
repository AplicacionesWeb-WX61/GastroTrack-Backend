namespace chefstock_platform.InventoryManagement.Domain.Model.Commands;

public record CreateProductCommand(string? Name, int Stock, string Image,
    string Description ,DateTime DueDate,int CategoryId);
