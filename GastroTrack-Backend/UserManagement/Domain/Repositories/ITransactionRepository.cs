using chefstock_platform.UserManagement.Domain.Model.Entities;
using chefstock_platform.Shared.Domain.Repositories;
using System.Threading.Tasks;

namespace chefstock_platform.UserManagement.Domain.Repositories
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        Task<Transaction?> GetByIdAsync(int id);
        Task UpdateAsync(Transaction transaction);
        Task DeleteAsync(int id);
    }
}