using chefstock_platform.RestaurantManagement.Domain.Model.Commands;
using chefstock_platform.RestaurantManagement.Interfaces.REST.Resources;

namespace chefstock_platform.RestaurantManagement.Interfaces.REST.Transform;

public static class UpdateMembrersCommandFromResourceAssembler
{
    public static UpdateMembrersCommand ToCommandFromResource(UpdateMembrersResource resource)
    {
        return new UpdateMembrersCommand(resource.MembersId, resource.MemberName, resource.Description, resource.Photo,resource.RoleId);
    }
}