using chefstock_platform.RestaurantManagement.Domain.Model.Entities;
using chefstock_platform.Shared.Domain.Repositories;

namespace chefstock_platform.RestaurantManagement.Domain.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    Task<Employee?> GetByIdAsync(int employeeId);
    Task UpdateAsync(Employee employee);
    Task DeleteAsync(int id);
}