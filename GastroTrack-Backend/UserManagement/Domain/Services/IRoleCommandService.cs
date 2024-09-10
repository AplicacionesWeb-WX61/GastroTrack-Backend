using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Model.Commands;

namespace chefstock_platform.UserManagement.Domain.Services
{
    public interface IRoleCommandService
    {
        Task<Role?> Handle(CreateRoleCommand command);
        Task<Role?> Handle(UpdateRoleCommand command);
        Task Handle(DeleteRoleCommand command);
    }
}