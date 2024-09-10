using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using System.Collections.Generic;
using System.Threading.Tasks;
using chefstock_platform.InventoryManagement.Domain.Model.Entities;

namespace chefstock_platform.InventoryManagement.Interfaces.ACL;

public interface ISupplierContextFacade
{
    Task<int> CreateSupplier(string supplierName, string contactName, string contactEmail, string phone, string address);
    Task<Supplier?> FetchSupplierById(int supplierId);
    Task<IEnumerable<Supplier>> FetchAllSuppliers();
    Task UpdateSupplier(int supplierId, string supplierName, string contactName, string contactEmail, string phone, string address);
    Task DeleteSupplier(int supplierId);
}