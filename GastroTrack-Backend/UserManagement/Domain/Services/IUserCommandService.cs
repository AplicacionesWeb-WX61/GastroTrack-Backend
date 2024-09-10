using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Model.Commands;

namespace chefstock_platform.UserManagement.Domain.Services
{
    public interface IUserCommandService
    {
        Task<User?> Handle(CreateUserCommand command);
        Task<User?> Handle(UpdateUserCommand command);
        Task Handle(DeleteUserCommand command);
    }
}