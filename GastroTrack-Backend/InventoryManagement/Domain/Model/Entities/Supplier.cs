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
        RestaunrantName = command.RestaunrantName;
        ContactEmail = command.ContactEmail;
        Phone = command.Phone;
        SupplierPhoto = command.SupplierPhoto ;
    }

    public void Update(UpdateSupplierCommand command)
    {
        SupplierId = command.SupplierId;
        SupplierName = command.SupplierName;
        RestaunrantName = command.RestaunrantName;
        ContactEmail = command.ContactEmail;
        Phone = command.Phone;
        SupplierPhoto = command.SupplierPhoto ;
    }
    public int SupplierId { get; set; }

    [MaxLength(50)]
    public string? SupplierName { get; set; }

    [MaxLength(50)]
    public string? RestaunrantName { get; set; }

    [MaxLength(100)]
    public string? ContactEmail { get; set; }

    [MaxLength(15)]
    public string? Phone { get; set; }

    [MaxLength(100)]
    public string? SupplierPhoto { get; set; }
    
    
    //public ICollection<Product?>? Products { get; set; }
}