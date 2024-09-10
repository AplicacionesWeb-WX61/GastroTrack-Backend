using chefstock_platform.RestaurantManagement.Domain.Model.Aggregates;
using chefstock_platform.RestaurantManagement.Domain.Repositories;
using chefstock_platform.RestaurantManagement.Domain.Services;
using chefstock_platform.RestaurantManagement.Domain.Model.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chefstock_platform.RestaurantManagement.Application.Internal.QueryServices;

public class RestaurantQueryService(IRestaurantRepository restaurantRepository) : IRestaurantQueryService
{
    public async Task<IEnumerable<Restaurant>> Handle(GetAllRestaurantsQuery query)
    {
        return await restaurantRepository.ListAsync();
    }

    public async Task<Restaurant?> Handle(GetRestaurantByIdQuery query)
    {
        return await restaurantRepository.GetByIdAsync(query.RestaurantId);
    }
}