using chefstock_platform.RestaurantManagement.Domain.Model.Queries;
using chefstock_platform.RestaurantManagement.Domain.Model.Entities;

namespace chefstock_platform.RestaurantManagement.Domain.Services
{
    public interface IMembrersQueryService
    {
        Task<IEnumerable<Membrers>> Handle(GetAllMembrersQuery query);
        Task<Membrers?> Handle(GetMembrersByIdQuery query);
    }
}