using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Model.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chefstock_platform.UserManagement.Domain.Services
{
    public interface IRoleQueryService
    {
        Task<IEnumerable<Role>> Handle(GetAllRolesQuery query);
        Task<Role?> Handle(GetRoleByIdQuery query);
    }
}