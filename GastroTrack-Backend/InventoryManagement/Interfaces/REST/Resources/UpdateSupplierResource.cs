namespace chefstock_platform.InventoryManagement.Interfaces.REST.Resources;

public record UpdateSupplierResource(int SupplierId, string SupplierName,string RestaunrantName, string ContactEmail, string Phone, string SupplierPhoto);