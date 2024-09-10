using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.Shared.Domain.Repositories;
using System.Threading.Tasks;

namespace chefstock_platform.UserManagement.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByIdAsync(int id);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}