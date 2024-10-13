using chefstock_platform.UserManagement.Domain.Model.Aggregates;

namespace chefstock_platform.UserManagement.Interfaces.ACL
{
    public interface IUserContextFacade
    {
        Task<int> CreateUser(string firstName, string lastName, string email, string password, string company);
        Task<User?> FetchUserById(int id);
        Task<IEnumerable<User>> FetchAllUsers();
        Task UpdateUser(int id,string firstName, string lastName, string email, string password, string company);
        Task DeleteUser(int id);
    }
}