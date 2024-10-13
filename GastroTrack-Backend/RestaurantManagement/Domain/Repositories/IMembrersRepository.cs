using chefstock_platform.RestaurantManagement.Domain.Model.Entities;
using chefstock_platform.Shared.Domain.Repositories;

namespace chefstock_platform.RestaurantManagement.Domain.Repositories;

public interface IMembrersRepository : IBaseRepository<Membrers>
{
    Task<Membrers?> GetByIdAsync(int membersId);
    Task UpdateAsync(Membrers membrers);
    Task DeleteAsync(int id);
}