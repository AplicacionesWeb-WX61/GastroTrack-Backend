using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Model.Commands;

namespace chefstock_platform.UserManagement.Domain.Services
{
    public interface IProfileCommandService
    {
        Task<Profile?> Handle(CreateProfileCommand command);
        Task<Profile?> Handle(UpdateProfileCommand command);
        Task Handle(DeleteProfileCommand command);
    }
}