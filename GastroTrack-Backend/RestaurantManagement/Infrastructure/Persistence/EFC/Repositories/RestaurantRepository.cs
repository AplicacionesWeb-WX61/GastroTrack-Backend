using chefstock_platform.RestaurantManagement.Domain.Model.Aggregates;
using chefstock_platform.RestaurantManagement.Domain.Repositories;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace chefstock_platform.RestaurantManagement.Infrastructure.Persistence.EFC.Repositories;

public class RestaurantRepository(AppDbContext context) : BaseRepository<Restaurant>(context), IRestaurantRepository
{
    public async Task<Restaurant?> GetByIdAsync(int restaurantId)
    {
        return await Context.Set<Restaurant>().FindAsync(restaurantId);
    }

    public async Task UpdateAsync(Restaurant restaurant)
    {
        Context.Set<Restaurant>().Update(restaurant);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int restaurantId)
    {
        var restaurant = await Context.Set<Restaurant>().FindAsync(restaurantId);
        if (restaurant != null)
        {
            Context.Set<Restaurant>().Remove(restaurant);
            await Context.SaveChangesAsync();
        }
    }
}