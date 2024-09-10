using chefstock_platform.RestaurantManagement.Domain.Model.Aggregates;
using chefstock_platform.RestaurantManagement.Domain.Model.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chefstock_platform.RestaurantManagement.Domain.Services
{
    public interface IRestaurantQueryService
    {
        Task<IEnumerable<Restaurant>> Handle(GetAllRestaurantsQuery query);
        Task<Restaurant?> Handle(GetRestaurantByIdQuery query);
    }
}