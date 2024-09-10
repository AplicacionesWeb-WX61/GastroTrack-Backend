using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.Shared.Domain.Repositories;
using System.Threading.Tasks;

namespace chefstock_platform.UserManagement.Domain.Repositories
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<Role?> GetByIdAsync(int roleId);
        Task UpdateAsync(Role role);
        Task DeleteAsync(int roleId);
    }
}