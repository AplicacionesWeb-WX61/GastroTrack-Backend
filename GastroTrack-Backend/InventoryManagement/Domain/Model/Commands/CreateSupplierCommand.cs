namespace chefstock_platform.InventoryManagement.Domain.Model.Commands;

public record CreateSupplierCommand(string SupplierName,string RestaunrantName, string ContactEmail, string Phone, string SupplierPhoto);
