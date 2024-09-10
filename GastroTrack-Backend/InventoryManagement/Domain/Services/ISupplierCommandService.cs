using chefstock_platform.InventoryManagement.Domain.Model.Commands;
using chefstock_platform.InventoryManagement.Domain.Model.Entities;

namespace chefstock_platform.InventoryManagement.Domain.Services;

public interface ISupplierCommandService
{
    Task<Supplier?> Handle(CreateSupplierCommand command);
    Task<Supplier?> Handle(UpdateSupplierCommand command);
    Task Handle(DeleteSupplierCommand command);
}