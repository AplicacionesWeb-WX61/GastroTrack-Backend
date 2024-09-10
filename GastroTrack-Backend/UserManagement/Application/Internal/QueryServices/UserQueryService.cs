using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Model.Queries;
using chefstock_platform.UserManagement.Domain.Repositories;
using chefstock_platform.UserManagement.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chefstock_platform.UserManagement.Application.Internal.QueryServices
{
    public class UserQueryService(IUserRepository userRepository) : IUserQueryService
    {
        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
        {
            return await userRepository.ListAsync();
        }

        public async Task<User?> Handle(GetUserByIdQuery query)
        {
            return await userRepository.GetByIdAsync(query.UserId);
        }
    }
}