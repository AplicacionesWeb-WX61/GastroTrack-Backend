using chefstock_platform.UserManagement.Domain.Model.Commands;
using chefstock_platform.UserManagement.Interfaces.REST.Resources;

namespace chefstock_platform.UserManagement.Interfaces.REST.Transform;

public class UpdateRoleCommandFromResourceAssembler
{
    public static UpdateRoleCommand ToCommandFromResource(UpdateRoleResource resource)
    {
        return new UpdateRoleCommand(resource.RoleId, resource.RoleName);
    }
}