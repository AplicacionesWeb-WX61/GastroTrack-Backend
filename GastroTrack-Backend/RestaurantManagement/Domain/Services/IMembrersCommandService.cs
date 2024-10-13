using chefstock_platform.RestaurantManagement.Domain.Model.Commands;
using chefstock_platform.RestaurantManagement.Domain.Model.Entities;

namespace chefstock_platform.RestaurantManagement.Domain.Services;

public interface IMembrersCommandService
{
    Task<Membrers?> Handle(CreateMembrersCommand command);
    Task<Membrers?> Handle(UpdateMembrersCommand command);
    Task Handle(DeleteMembrersCommand command);
}