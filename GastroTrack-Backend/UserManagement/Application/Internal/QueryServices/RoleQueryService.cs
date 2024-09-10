using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Model.Queries;
using chefstock_platform.UserManagement.Domain.Repositories;
using chefstock_platform.UserManagement.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chefstock_platform.UserManagement.Application.Internal.QueryServices
{
    public class RoleQueryService(IRoleRepository roleRepository) : IRoleQueryService
    {
        public async Task<IEnumerable<Role>> Handle(GetAllRolesQuery query)
        {
            return await roleRepository.ListAsync();
        }

        public async Task<Role?> Handle(GetRoleByIdQuery query)
        {
            return await roleRepository.GetByIdAsync(query.RoleId);
        }
    }
}