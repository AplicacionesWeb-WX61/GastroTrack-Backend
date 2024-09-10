using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Model.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chefstock_platform.UserManagement.Domain.Services
{
    public interface IProfileQueryService
    {
        Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query);
        Task<Profile?> Handle(GetProfileByIdQuery query);
    }
}