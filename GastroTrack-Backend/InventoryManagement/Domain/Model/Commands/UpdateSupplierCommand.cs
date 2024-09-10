namespace chefstock_platform.InventoryManagement.Domain.Model.Commands;

public record UpdateSupplierCommand(int SupplierId, string SupplierName, string ContactName, string ContactEmail, string Phone, string Address);
