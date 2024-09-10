using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Repositories;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace chefstock_platform.UserManagement.Infrastructure.Persistence.EFC.Repositories
{
    public class ProfileRepository(AppDbContext context) : BaseRepository<Profile>(context), IProfileRepository
    {
        public async Task<Profile?> GetByIdAsync(int id)
        {
            return await Context.Set<Profile>().FindAsync(id);
        }

        public async Task UpdateAsync(Profile profile)
        {
            Context.Set<Profile>().Update(profile);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var profile = await Context.Set<Profile>().FindAsync(id);
            if (profile != null)
            {
                Context.Set<Profile>().Remove(profile);
                await Context.SaveChangesAsync();
            }
        }
    }
}