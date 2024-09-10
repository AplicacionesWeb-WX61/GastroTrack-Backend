using chefstock_platform.RestaurantManagement.Domain.Model.Aggregates;
using chefstock_platform.RestaurantManagement.Domain.Model.Commands;
using chefstock_platform.RestaurantManagement.Domain.Model.Queries;
using chefstock_platform.RestaurantManagement.Domain.Services;

namespace chefstock_platform.RestaurantManagement.Interfaces.ACL.Services
{
    public class RestaurantContextFacade(
        IRestaurantCommandService restaurantCommandService,
        IRestaurantQueryService restaurantQueryService)
        : IRestaurantContextFacade
    {
        public async Task<int> CreateRestaurant(string name, string location, string type)
        {
            var createRestaurantCommand = new CreateRestaurantCommand(name, location, type);
            var restaurant = await restaurantCommandService.Handle(createRestaurantCommand);
            return restaurant?.RestaurantId ?? 0;
        }

        public async Task<Restaurant?> FetchRestaurantById(int id)
        {
            var getRestaurantByIdQuery = new GetRestaurantByIdQuery(id);
            return await restaurantQueryService.Handle(getRestaurantByIdQuery);
        }

        public async Task<IEnumerable<Restaurant>> FetchAllRestaurants()
        {
            var getAllRestaurantsQuery = new GetAllRestaurantsQuery();
            return await restaurantQueryService.Handle(getAllRestaurantsQuery);
        }

        public async Task UpdateRestaurant(int id, string name, string location, string type)
        {
            var updateRestaurantCommand = new UpdateRestaurantCommand(id, name, location, type);
            await restaurantCommandService.Handle(updateRestaurantCommand);
        }

        public async Task DeleteRestaurant(int id)
        {
            var deleteRestaurantCommand = new DeleteRestaurantCommand(id);
            await restaurantCommandService.Handle(deleteRestaurantCommand);
        }
    }
}