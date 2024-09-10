using chefstock_platform.RestaurantManagement.Domain.Model.Commands;
using chefstock_platform.RestaurantManagement.Interfaces.REST.Resources;

namespace chefstock_platform.RestaurantManagement.Interfaces.REST.Transform;

public static class UpdateRestaurantCommandFromResourceAssembler
{
    public static UpdateRestaurantCommand ToCommandFromResource(UpdateRestaurantResource resource)
    {
        return new UpdateRestaurantCommand(resource.RestaurantId, resource.Name, resource.Location, resource.Type);
    }
}