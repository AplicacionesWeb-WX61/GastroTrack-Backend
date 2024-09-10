using chefstock_platform.RestaurantManagement.Domain.Model.Aggregates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chefstock_platform.RestaurantManagement.Interfaces.ACL
{
    public interface IRestaurantContextFacade
    {
        Task<int> CreateRestaurant(string name, string location, string type);
        Task<Restaurant?> FetchRestaurantById(int id);
        Task<IEnumerable<Restaurant>> FetchAllRestaurants();
        Task UpdateRestaurant(int restaurantId, string name, string location, string type);
        Task DeleteRestaurant(int restaurantId);
    }
}