using chefstock_platform.RestaurantManagement.Domain.Model.Aggregates;

namespace chefstock_platform.InventoryManagement.Domain.Model.Aggregates;

public class Inventory
{
    public int InventoryId { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    
    public int RestaurantId { get; set; }
    public Restaurant? Restaurant { get; set; }
}