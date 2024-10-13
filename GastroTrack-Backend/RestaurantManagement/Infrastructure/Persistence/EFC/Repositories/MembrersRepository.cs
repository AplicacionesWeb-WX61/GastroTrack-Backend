using chefstock_platform.RestaurantManagement.Domain.Model.Entities;
using chefstock_platform.RestaurantManagement.Domain.Repositories;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace chefstock_platform.RestaurantManagement.Infrastructure.Persistence.EFC.Repositories;

public class MembrersRepository(AppDbContext context) : BaseRepository<Membrers>(context), IMembrersRepository
{
    public async Task<Membrers?> GetByIdAsync(int membersId)
    {
        return await Context.Set<Membrers>().FindAsync(membersId);
    }

    public async Task UpdateAsync(Membrers membrers)
    {
        Context.Set<Membrers>().Update(membrers);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int membersId)
    {
        var employee = await Context.Set<Membrers>().FindAsync(membersId);
        if (employee != null)
        {
            Context.Set<Membrers>().Remove(employee);
            await Context.SaveChangesAsync();
        }
    }
}