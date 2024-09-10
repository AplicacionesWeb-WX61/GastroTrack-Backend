using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Model.Commands;
using chefstock_platform.UserManagement.Domain.Repositories;
using chefstock_platform.UserManagement.Domain.Services;
using chefstock_platform.Shared.Domain.Repositories;
using System;

namespace chefstock_platform.UserManagement.Application.Internal.CommandServices
{
    public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork)
        : IProfileCommandService
    {
        public async Task<Profile?> Handle(CreateProfileCommand command)
        {
            var profile = new Profile(command);
            try
            {
                await profileRepository.AddAsync(profile);
                await unitOfWork.CompleteAsync();
                return profile;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
                throw;
            }
        }

        public async Task<Profile?> Handle(UpdateProfileCommand command)
        {
            var profile = await profileRepository.GetByIdAsync(command.ProfileId);
            if (profile != null)
            {
                profile.Update(command);
                await profileRepository.UpdateAsync(profile);
                await unitOfWork.CompleteAsync();
                return profile;
            }
            else
            {
                Console.WriteLine($"Profile with id {command.ProfileId} not found");
                throw new Exception($"Profile with id {command.ProfileId} not found");
            }
        }

        public async Task Handle(DeleteProfileCommand command)
        {
            var profile = await profileRepository.GetByIdAsync(command.ProfileId);
            if (profile != null)
            {
                await profileRepository.DeleteAsync(profile.ProfileId);
                await unitOfWork.CompleteAsync();
            }
            else
            {
                Console.WriteLine($"Profile with id {command.ProfileId} not found");
                throw new Exception($"Profile with id {command.ProfileId} not found");
            }
        }
    }
}