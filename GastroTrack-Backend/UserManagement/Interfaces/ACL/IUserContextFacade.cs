using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Model.ValueObjects;

namespace chefstock_platform.UserManagement.Interfaces.ACL
{
    public interface IUserContextFacade
    {
        Task<int> CreateUser(string firstName, string lastName, Email email, string password, string phone, string address, int roleId);
        Task<User?> FetchUserById(int id);
        Task<IEnumerable<User>> FetchAllUsers();
        Task UpdateUser(int id,string firstName, string lastName, Email email, string password, string phone, string address, int roleId);
        Task DeleteUser(int id);
    }
}