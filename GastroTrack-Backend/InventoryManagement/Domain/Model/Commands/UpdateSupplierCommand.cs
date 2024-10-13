namespace chefstock_platform.InventoryManagement.Domain.Model.Commands;

public record UpdateSupplierCommand(int SupplierId, string SupplierName, string RestaunrantName, string ContactEmail, string Phone, string SupplierPhoto);
