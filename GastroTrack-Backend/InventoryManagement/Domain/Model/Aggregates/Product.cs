using System.ComponentModel.DataAnnotations;
using chefstock_platform.InventoryManagement.Domain.Model.Commands;
using chefstock_platform.InventoryManagement.Domain.Model.Entities;
using chefstock_platform.InventoryManagement.Domain.Model.ValueObjects;
using chefstock_platform.UserManagement.Domain.Model.Entities;

namespace chefstock_platform.InventoryManagement.Domain.Model.Aggregates;

public class Product
{
    public int ProductId { get; set; }
    
    [MaxLength(50)]
    public string? Name { get; set; }
    
    public ECategory CategoryId { get; set; }
    
    public string? DateManufacture { get; set; }
    
    public string? DueDate { get; set; }
    public int Stock { get; set; }
    
    public string? State { get; set; }
    public string? Image { get; set; }
    public ICollection<Inventory>? Inventories { get; set; }
    
    
    

    //public int SupplierId { get; set; }
    //public Supplier? Supplier { get; set; }
    
    public IEnumerable<Transaction>? Transactions { get; set; }
    public Product()
    {

    }
    public Product(int productId, string name, ECategory categoryId, string? dateManufacture, string? dueDate, int stock, string? state, string? image)
    {
        ProductId = productId;
        Name = name;
        CategoryId = categoryId;
        DateManufacture = dateManufacture;
        DueDate = dueDate;
        Stock = stock;
        State = state;
        Image = image;
    }

    
    public Product(CreateProductCommand command)
    {
        Name = command.Name;
        CategoryId = (ECategory)command.CategoryId; 
        DateManufacture = command.DateManufacture; 
        DueDate = command.DueDate; 
        Stock = command.Stock;
        State = command.State; 
        Image = command.Image; 
    }

    // Método para actualizar el producto
    public void Update(UpdateProductCommand command)
    {
        ProductId = command.ProductId;
        Name = command.Name;
        CategoryId = (ECategory)command.CategoryId; 
        DateManufacture = command.DateManufacture; 
        DueDate = command.DueDate; 
        Stock = command.Stock;
        State = command.State; 
        Image = command.Image; 
    }
}