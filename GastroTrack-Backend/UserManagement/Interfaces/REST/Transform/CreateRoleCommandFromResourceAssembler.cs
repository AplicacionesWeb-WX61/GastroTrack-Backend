using chefstock_platform.UserManagement.Domain.Model.Commands;
using chefstock_platform.UserManagement.Interfaces.REST.Resources;

namespace chefstock_platform.UserManagement.Interfaces.REST.Transform;

public class CreateRoleCommandFromResourceAssembler
{
    public static CreateRoleCommand ToCommandFromResource(CreateRoleResource resource)
    {
        return new CreateRoleCommand(resource.RoleName);
    }
}