using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Commands;
using chefstock_platform.InventoryManagement.Domain.Model.Queries;
using chefstock_platform.InventoryManagement.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using chefstock_platform.InventoryManagement.Domain.Model.Entities;

namespace chefstock_platform.InventoryManagement.Interfaces.ACL.Services;

public class SupplierContextFacade(
    ISupplierCommandService supplierCommandService,
    ISupplierQueryService supplierQueryService)
    : ISupplierContextFacade
{
    public async Task<int> CreateSupplier(string supplierName, string contactName, string contactEmail, string phone, string address)
    {
        var createSupplierCommand = new CreateSupplierCommand(supplierName, contactName, contactEmail, phone, address);
        var supplier = await supplierCommandService.Handle(createSupplierCommand);
        return supplier?.SupplierId ?? 0;
    }

    public async Task<Supplier?> FetchSupplierById(int id)
    {
        var getSupplierByIdQuery = new GetSupplierByIdQuery(id);
        return await supplierQueryService.Handle(getSupplierByIdQuery);
    }

    public async Task<IEnumerable<Supplier>> FetchAllSuppliers()
    {
        var getAllSuppliersQuery = new GetAllSuppliersQuery();
        return await supplierQueryService.Handle(getAllSuppliersQuery);
    }

    public async Task UpdateSupplier(int id, string supplierName, string contactName, string contactEmail, string phone, string address)
    {
        var updateSupplierCommand = new UpdateSupplierCommand(id, supplierName, contactName, contactEmail, phone, address);
        await supplierCommandService.Handle(updateSupplierCommand);
    }

    public async Task DeleteSupplier(int id)
    {
        var deleteSupplierCommand = new DeleteSupplierCommand(id);
        await supplierCommandService.Handle(deleteSupplierCommand);
    }
}