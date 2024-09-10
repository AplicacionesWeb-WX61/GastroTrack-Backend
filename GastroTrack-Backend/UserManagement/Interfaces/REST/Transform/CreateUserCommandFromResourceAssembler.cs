using chefstock_platform.UserManagement.Domain.Model.Commands;
using chefstock_platform.UserManagement.Interfaces.REST.Resources;

namespace chefstock_platform.UserManagement.Interfaces.REST.Transform;

public class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand ToCommandFromResource(CreateUserResource resource)
    {
        return new CreateUserCommand(resource.FirstName, resource.LastName, resource.Email, resource.Password, resource.Phone, resource.Address, resource.RoleId);
    }
}