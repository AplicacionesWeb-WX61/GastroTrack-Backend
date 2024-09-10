namespace chefstock_platform.InventoryManagement.Interfaces.REST.Resources;

public record CreateSupplierResource(string SupplierName, string ContactName, string ContactEmail, string Phone, string Address);