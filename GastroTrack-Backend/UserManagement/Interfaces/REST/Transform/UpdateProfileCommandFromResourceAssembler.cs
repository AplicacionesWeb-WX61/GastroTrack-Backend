using chefstock_platform.UserManagement.Domain.Model.Commands;
using chefstock_platform.UserManagement.Interfaces.REST.Resources;

namespace chefstock_platform.UserManagement.Interfaces.REST.Transform;

public class UpdateProfileCommandFromResourceAssembler
{
    public static UpdateProfileCommand ToCommandFromResource(UpdateProfileResource resource)
    {
        return new UpdateProfileCommand(resource.ProfileId, resource.UserId, resource.Bio, resource.ProfilePicture);
    }
}