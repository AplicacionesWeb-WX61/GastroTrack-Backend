using chefstock_platform.UserManagement.Domain.Model.Commands;
using chefstock_platform.UserManagement.Interfaces.REST.Resources;

namespace chefstock_platform.UserManagement.Interfaces.REST.Transform;

public class UpdateUserCommandFromResourceAssembler
{
    public static UpdateUserCommand ToCommandFromResource(UpdateUserResource resource)
    {
        return new UpdateUserCommand(resource.UserId, resource.FirstName, resource.LastName, resource.Email, resource.Password, resource.Phone, resource.Address, resource.RoleId);
    }
}