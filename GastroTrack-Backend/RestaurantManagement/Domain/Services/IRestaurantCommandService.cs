using chefstock_platform.RestaurantManagement.Domain.Model.Aggregates;
using chefstock_platform.RestaurantManagement.Domain.Model.Commands;

namespace chefstock_platform.RestaurantManagement.Domain.Services;

public interface IRestaurantCommandService
{
    Task<Restaurant?> Handle(CreateRestaurantCommand command);
    Task<Restaurant?> Handle(UpdateRestaurantCommand command);
    Task Handle(DeleteRestaurantCommand command);
}