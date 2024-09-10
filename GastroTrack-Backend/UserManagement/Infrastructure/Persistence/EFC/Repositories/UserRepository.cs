using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Repositories;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace chefstock_platform.UserManagement.Infrastructure.Persistence.EFC.Repositories
{
    public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
    {
        public async Task<User?> GetByIdAsync(int id)
        {
            return await Context.Set<User>().FindAsync(id);
        }

        public async Task UpdateAsync(User user)
        {
            Context.Set<User>().Update(user);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await Context.Set<User>().FindAsync(id);
            if (user != null)
            {
                Context.Set<User>().Remove(user);
                await Context.SaveChangesAsync();
            }
        }
    }
}