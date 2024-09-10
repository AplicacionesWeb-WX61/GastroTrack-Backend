using chefstock_platform.UserManagement.Domain.Model.Aggregates;

namespace chefstock_platform.UserManagement.Interfaces.ACL
{
    public interface IProfileContextFacade
    {
        Task<int> CreateProfile(int userId, string bio, string profilePicture);
        Task<Profile?> FetchProfileById(int id);
        Task<IEnumerable<Profile>> FetchAllProfiles();
        Task UpdateProfile(int profileId,int userId, string bio, string profilePicture);
        Task DeleteProfile(int id);
    }
}
