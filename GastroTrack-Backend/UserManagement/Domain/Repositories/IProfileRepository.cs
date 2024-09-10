using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.Shared.Domain.Repositories;
using System.Threading.Tasks;

namespace chefstock_platform.UserManagement.Domain.Repositories
{
    public interface IProfileRepository : IBaseRepository<Profile>
    {
        Task<Profile?> GetByIdAsync(int id);
        Task UpdateAsync(Profile profile);
        Task DeleteAsync(int id);
    }
}