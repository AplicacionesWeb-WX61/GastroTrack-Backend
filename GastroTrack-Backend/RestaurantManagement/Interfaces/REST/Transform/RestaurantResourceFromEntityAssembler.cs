using chefstock_platform.RestaurantManagement.Domain.Model.Aggregates;
using chefstock_platform.RestaurantManagement.Interfaces.REST.Resources;

namespace chefstock_platform.RestaurantManagement.Interfaces.REST.Transform;

public static class RestaurantResourceFromEntityAssembler
{
    public static RestaurantResource ToResourceFromEntity(Restaurant restaurant)
    {
        return new RestaurantResource(restaurant.RestaurantId, restaurant.Name, restaurant.Location, restaurant.Type);
    }
}