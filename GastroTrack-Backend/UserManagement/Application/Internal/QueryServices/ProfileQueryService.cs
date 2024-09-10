using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Model.Queries;
using chefstock_platform.UserManagement.Domain.Repositories;
using chefstock_platform.UserManagement.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chefstock_platform.UserManagement.Application.Internal.QueryServices
{
    public class ProfileQueryService(IProfileRepository profileRepository) : IProfileQueryService
    {
        public async Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query)
        {
            return await profileRepository.ListAsync();
        }

        public async Task<Profile?> Handle(GetProfileByIdQuery query)
        {
            return await profileRepository.GetByIdAsync(query.ProfileId);
        }
    }
}