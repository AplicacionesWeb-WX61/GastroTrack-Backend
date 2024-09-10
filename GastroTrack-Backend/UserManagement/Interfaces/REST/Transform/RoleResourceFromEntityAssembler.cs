using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Interfaces.REST.Resources;

namespace chefstock_platform.UserManagement.Interfaces.REST.Transform;

public static class RoleResourceFromEntityAssembler
{
    public static RoleResource ToResourceFromEntity(Role role)
    {
        return new RoleResource(role.RoleId, role.RoleName);
    }
}