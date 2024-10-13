using chefstock_platform.RestaurantManagement.Domain.Repositories;
using chefstock_platform.RestaurantManagement.Domain.Services;
using chefstock_platform.RestaurantManagement.Domain.Model.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;
using chefstock_platform.RestaurantManagement.Domain.Model.Entities;

namespace chefstock_platform.RestaurantManagement.Application.Internal.QueryServices;

public class MembrersQueryService(IMembrersRepository membrersRepository) : IMembrersQueryService
{
    public async Task<IEnumerable<Membrers>> Handle(GetAllMembrersQuery query)
    {
        return await membrersRepository.ListAsync();
    }

    public async Task<Membrers?> Handle(GetMembrersByIdQuery query)
    {
        return await membrersRepository.GetByIdAsync(query.MembersId);
    }
}