using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Model.Commands;
using chefstock_platform.UserManagement.Domain.Model.Queries;
using chefstock_platform.UserManagement.Domain.Services;

namespace chefstock_platform.UserManagement.Interfaces.ACL.Services
{
    public class ProfileContextFacade(
        IProfileCommandService profileCommandService,
        IProfileQueryService profileQueryService)
        : IProfileContextFacade
    {
        public async Task<int> CreateProfile(int userId, string bio, string profilePicture)
        {
            var createProfileCommand = new CreateProfileCommand(userId, bio, profilePicture);
            var profile = await profileCommandService.Handle(createProfileCommand);
            return profile?.ProfileId ?? 0;
        }

        public async Task<Profile?> FetchProfileById(int id)
        {
            var getProfileByIdQuery = new GetProfileByIdQuery(id);
            return await profileQueryService.Handle(getProfileByIdQuery);
        }

        public async Task<IEnumerable<Profile>> FetchAllProfiles()
        {
            var getAllProfilesQuery = new GetAllProfilesQuery();
            return await profileQueryService.Handle(getAllProfilesQuery);
        }

        public async Task UpdateProfile(int profileId, int userId, string bio, string profilePicture)
        {
            var updateProfileCommand = new UpdateProfileCommand(profileId, userId, bio, profilePicture);
            await profileCommandService.Handle(updateProfileCommand);
        }

        public async Task DeleteProfile(int id)
        {
            var deleteProfileCommand = new DeleteProfileCommand(id);
            await profileCommandService.Handle(deleteProfileCommand);
        }
    }
}