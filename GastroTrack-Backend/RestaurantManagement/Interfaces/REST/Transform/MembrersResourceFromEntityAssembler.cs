using chefstock_platform.RestaurantManagement.Domain.Model.Entities;
using chefstock_platform.RestaurantManagement.Interfaces.REST.Resources;

namespace chefstock_platform.RestaurantManagement.Interfaces.REST.Transform;

public static class MembrersResourceFromEntityAssembler
{
    public static MembrersResource ToResourceFromEntity(Membrers membrers)
    {
        return new MembrersResource(membrers.MembersId, membrers.MemberName, membrers.Description, membrers.Photo, membrers.RoleId);
    }
}