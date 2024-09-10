using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Model.Commands;
using chefstock_platform.UserManagement.Domain.Model.Queries;
using chefstock_platform.UserManagement.Domain.Services;

using chefstock_platform.UserManagement.Domain.Model.ValueObjects;

namespace chefstock_platform.UserManagement.Interfaces.ACL.Services
{
    public class UserContextFacade(IUserCommandService userCommandService, IUserQueryService userQueryService)
        : IUserContextFacade
    {

        public async Task<int> CreateUser(string firstName, string lastName, Email email, string password, string phone, string address, int roleId)
        {
            var createUserCommand = new CreateUserCommand(firstName, lastName, email, phone, address, phone,roleId);
            var user = await userCommandService.Handle(createUserCommand);
            return user?.UserId ?? 0;
        }

        public async Task<User?> FetchUserById(int id)
        {
            var getUserByIdQuery = new GetUserByIdQuery(id);
            return await userQueryService.Handle(getUserByIdQuery);
        }

        public async Task<IEnumerable<User>> FetchAllUsers()
        {
            var getAllUsersQuery = new GetAllUsersQuery();
            return await userQueryService.Handle(getAllUsersQuery);
        }

        public async Task UpdateUser(int id, string firstName, string lastName, Email email, string password, string phone, string address, int roleId)
        {
            var updateUserCommand = new UpdateUserCommand(id, firstName, lastName, email, phone, address, phone,roleId);
            await userCommandService.Handle(updateUserCommand);
        }

        public async Task DeleteUser(int id)
        {
            var deleteUserCommand = new DeleteUserCommand(id);
            await userCommandService.Handle(deleteUserCommand);
        }
    }
}