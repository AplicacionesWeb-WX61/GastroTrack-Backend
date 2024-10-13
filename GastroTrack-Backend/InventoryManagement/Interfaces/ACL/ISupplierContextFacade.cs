using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using System.Collections.Generic;
using System.Threading.Tasks;
using chefstock_platform.InventoryManagement.Domain.Model.Entities;

namespace chefstock_platform.InventoryManagement.Interfaces.ACL;

public interface ISupplierContextFacade
{
    Task<int> CreateSupplier(string supplierName, string restaunrantName, string contactEmail, string phone, string supplierPhoto);
    Task<Supplier?> FetchSupplierById(int supplierId);
    Task<IEnumerable<Supplier>> FetchAllSuppliers();
    Task UpdateSupplier(int supplierId, string supplierName,string restaunrantName, string contactEmail, string phone, string supplierPhoto);
    Task DeleteSupplier(int supplierId);
}