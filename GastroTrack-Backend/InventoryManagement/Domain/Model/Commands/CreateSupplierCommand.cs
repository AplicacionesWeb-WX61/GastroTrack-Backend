namespace chefstock_platform.InventoryManagement.Domain.Model.Commands;

public record CreateSupplierCommand(string SupplierName, string ContactName, string ContactEmail, string Phone, string Address);
