using chefstock_platform.RestaurantManagement.Domain.Model.Aggregates;
using chefstock_platform.Shared.Domain.Repositories;

namespace chefstock_platform.RestaurantManagement.Domain.Repositories;

public interface IRestaurantRepository : IBaseRepository<Restaurant>
{
    Task<Restaurant?> GetByIdAsync(int restaurantId);
    Task UpdateAsync(Restaurant restaurant);
    Task DeleteAsync(int id);
}