using chefstock_platform.UserManagement.Domain.Model.Entities;
using chefstock_platform.UserManagement.Domain.Repositories;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace chefstock_platform.UserManagement.Infrastructure.Persistence.EFC.Repositories
{
    public class TransactionRepository(AppDbContext context)
        : BaseRepository<Transaction>(context), ITransactionRepository
    {
        public async Task<Transaction?> GetByIdAsync(int id)
        {
            return await Context.Set<Transaction>().FindAsync(id);
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            Context.Set<Transaction>().Update(transaction);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var transaction = await Context.Set<Transaction>().FindAsync(id);
            if (transaction != null)
            {
                Context.Set<Transaction>().Remove(transaction);
                await Context.SaveChangesAsync();
            }
        }
    }
}