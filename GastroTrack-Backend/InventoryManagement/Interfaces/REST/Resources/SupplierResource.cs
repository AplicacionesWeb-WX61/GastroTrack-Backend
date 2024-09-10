namespace chefstock_platform.InventoryManagement.Interfaces.REST.Resources;

public record SupplierResource(int SupplierId, string? SupplierName, string? ContactName, string? ContactEmail, string? Phone, string? Address);
