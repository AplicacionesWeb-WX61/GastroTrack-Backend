using chefstock_platform.RestaurantManagement.Domain.Model.Aggregates;
using System.Collections.Generic;
using System.Threading.Tasks;
using chefstock_platform.RestaurantManagement.Domain.Model.Entities;

namespace chefstock_platform.RestaurantManagement.Interfaces.ACL
{
    public interface IEmployeeContextFacade
    {
        Task<int> CreateEmployee(string firstName, string lastName, string email, string phone, string position, int restaurantId);
        Task<Employee?> FetchEmployeeById(int employeeId);
        Task<IEnumerable<Employee>> FetchAllEmployees();
        Task UpdateEmployee(int employeeId, string firstName, string lastName, string email, string phone, string position, int restaurantId);
        Task DeleteEmployee(int employeeId);
    }
}