using chefstock_platform.RestaurantManagement.Domain.Model.Commands;
using chefstock_platform.RestaurantManagement.Interfaces.REST.Resources;

namespace chefstock_platform.RestaurantManagement.Interfaces.REST.Transform;

public class CreateMembrersCommandFromResourceAssembler
{
    public static CreateMembrersCommand ToCommandFromResource(CreateMembrersResource resource)
    {
        return new CreateMembrersCommand(resource.MemberName, resource.Description, resource.Photo, resource.RoleId);
    }
}