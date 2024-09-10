using chefstock_platform.RestaurantManagement.Domain.Model.Commands;
using chefstock_platform.RestaurantManagement.Domain.Model.Entities;

namespace chefstock_platform.RestaurantManagement.Domain.Model.Aggregates;

public class Restaurant
{
    public Restaurant()
    {

    }
    public Restaurant(CreateRestaurantCommand command)
    {
        Name = command.Name;
        Location = command.Location;
        Type = command.Type;
    }
    public void Update(UpdateRestaurantCommand command)
    {
        RestaurantId = command.RestaurantId;
        Name = command.Name;
        Location = command.Location;
        Type = command.Type;
    }
    public int RestaurantId { get; set; }
    public string? Name { get; set; }
    public string? Location { get; set; }
    public string? Type { get; set; }

    // Navigation property
    public List<Employee?>? Employees { get; set; }
}