using chefstock_platform.RestaurantManagement.Domain.Model.Commands;
using chefstock_platform.RestaurantManagement.Interfaces.REST.Resources;

namespace chefstock_platform.RestaurantManagement.Interfaces.REST.Transform;

public static class CreateRestaurantCommandFromResourceAssembler
{
    public static CreateRestaurantCommand ToCommandFromResource(CreateRestaurantResource resource)
    {
        return new CreateRestaurantCommand(resource.Name, resource.Location, resource.Type);
    }
}