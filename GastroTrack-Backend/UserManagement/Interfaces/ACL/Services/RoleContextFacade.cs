using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Model.Commands;
using chefstock_platform.UserManagement.Domain.Model.Queries;
using chefstock_platform.UserManagement.Domain.Services;


namespace chefstock_platform.UserManagement.Interfaces.ACL.Services
{
    public class RoleContextFacade(IRoleCommandService roleCommandService, IRoleQueryService roleQueryService)
        : IRoleContextFacade
    {
        public async Task<int> CreateRole(string roleName)
        {
            var createRoleCommand = new CreateRoleCommand(roleName);
            var role = await roleCommandService.Handle(createRoleCommand);
            return role?.RoleId ?? 0;
        }

        public async Task<Role?> FetchRoleById(int id)
        {
            var getRoleByIdQuery = new GetRoleByIdQuery(id);
            return await roleQueryService.Handle(getRoleByIdQuery);
        }

        public async Task<IEnumerable<Role>> FetchAllRoles()
        {
            var getAllRolesQuery = new GetAllRolesQuery();
            return await roleQueryService.Handle(getAllRolesQuery);
        }

        public async Task UpdateRole(int roleId,string roleName)
        {
            var updateRoleCommand = new UpdateRoleCommand(roleId, roleName);
            await roleCommandService.Handle(updateRoleCommand);
        }

        public async Task DeleteRole(int id)
        {
            var deleteRoleCommand = new DeleteRoleCommand(id);
            await roleCommandService.Handle(deleteRoleCommand);
        }
    }
}