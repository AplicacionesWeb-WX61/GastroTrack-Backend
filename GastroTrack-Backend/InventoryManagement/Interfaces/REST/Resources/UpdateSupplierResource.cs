namespace chefstock_platform.InventoryManagement.Interfaces.REST.Resources;

public record UpdateSupplierResource(int SupplierId, string SupplierName, string ContactName, string ContactEmail, string Phone, string Address);