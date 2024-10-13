
namespace chefstock_platform.InventoryManagement.Domain.Model.Aggregates;

public class Inventory
{
    public int InventoryId { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}