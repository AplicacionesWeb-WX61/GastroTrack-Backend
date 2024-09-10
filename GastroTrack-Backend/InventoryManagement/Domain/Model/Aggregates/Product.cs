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

    [MaxLength(200)]
    public string? Description { get; set; }
    public int Stock { get; set; }
    
    public ECategory CategoryId { get; set; }
    public string? Image { get; set; }
    public DateTime DueDate { get; set; }
    
    public ICollection<Inventory>? Inventories { get; set; }
    
    
    

    //public int SupplierId { get; set; }
    //public Supplier? Supplier { get; set; }
    
    public IEnumerable<Transaction>? Transactions { get; set; }
    public Product()
    {

    }
    public Product(int productId, string name, string description, int stock, string image, DateTime dueDate)
    {
        ProductId = productId;
        Name = name;
        Description = description;
        Stock = stock;
        Image = image;
        DueDate = dueDate;
        
    }
    public Product(CreateProductCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        Stock = command.Stock;
        Image = command.Image;
        DueDate = command.DueDate;
        CategoryId = (ECategory)command.CategoryId;
    }
    public void Update(UpdateProductCommand command)
    {
        ProductId = command.ProductId;
        Name = command.Name;
        Description = command.Description;
        Stock = command.Stock;
        Image = command.Image;
        DueDate = command.DueDate;
        CategoryId = (ECategory)command.CategoryId;
    }
}