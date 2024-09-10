using System.ComponentModel.DataAnnotations;
using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Commands;

namespace chefstock_platform.InventoryManagement.Domain.Model.Entities;

public class Supplier
{
    public Supplier()
    {

    }
    
    public Supplier(CreateSupplierCommand command)
    {
        SupplierName = command.SupplierName;
        ContactName = command.ContactName;
        ContactEmail = command.ContactEmail;
        Phone = command.Phone;
        Address = command.Address;
    }

    public void Update(UpdateSupplierCommand command)
    {
        SupplierId = command.SupplierId;
        SupplierName = command.SupplierName;
        ContactName = command.ContactName;
        ContactEmail = command.ContactEmail;
        Phone = command.Phone;
        Address = command.Address;
    }
    public int SupplierId { get; set; }

    [MaxLength(50)]
    public string? SupplierName { get; set; }

    [MaxLength(50)]
    public string? ContactName { get; set; }

    [MaxLength(100)]
    public string? ContactEmail { get; set; }

    [MaxLength(15)]
    public string? Phone { get; set; }

    [MaxLength(100)]
    public string? Address { get; set; }

    //public ICollection<Product?>? Products { get; set; }
}