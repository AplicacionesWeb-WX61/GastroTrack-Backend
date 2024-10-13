using chefstock_platform.RestaurantManagement.Domain.Model.Entities;

namespace chefstock_platform.RestaurantManagement.Interfaces.ACL
{
    public interface IMembersContextFacade
    {
        Task<int> CreateEmployee(string memberName, string description, string photo, int roleId);
        Task<Membrers?> FetchEmployeeById(int membersId);
        Task<IEnumerable<Membrers>> FetchAllEmployees();
        Task UpdateEmployee(int membersId, string memberName, string description, string photo, int roleId);
        Task DeleteEmployee(int membersId);
    }
}