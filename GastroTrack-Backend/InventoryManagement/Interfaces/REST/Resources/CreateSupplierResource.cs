namespace chefstock_platform.InventoryManagement.Interfaces.REST.Resources;

public record CreateSupplierResource(string SupplierName,  string RestaunrantName, string ContactEmail, string Phone, string SupplierPhoto);