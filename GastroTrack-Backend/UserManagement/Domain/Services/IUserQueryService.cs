using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Model.Queries;


namespace chefstock_platform.UserManagement.Domain.Services
{
    public interface IUserQueryService
    {
        Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
        Task<User?> Handle(GetUserByIdQuery query);
    }
}