using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Model.Commands;
using chefstock_platform.UserManagement.Domain.Repositories;
using chefstock_platform.UserManagement.Domain.Services;
using chefstock_platform.Shared.Domain.Repositories;
using System;

namespace chefstock_platform.UserManagement.Application.Internal.CommandServices
{
    public class UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork) : IUserCommandService
    {
        public async Task<User?> Handle(CreateUserCommand command)
        {
            var user = new User(command);
            try
            {
                await userRepository.AddAsync(user);
                await unitOfWork.CompleteAsync();
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while creating the user: {e.Message}");
                throw;
            }
        }

        public async Task<User?> Handle(UpdateUserCommand command)
        {
            var user = await userRepository.GetByIdAsync(command.UserId);
            if (user != null)
            {
                user.Update(command);
                await userRepository.UpdateAsync(user);
                await unitOfWork.CompleteAsync();
                return user;
            }
            else
            {
                Console.WriteLine($"User with id {command.UserId} not found");
                throw new Exception($"User with id {command.UserId} not found");
            }
        }

        public async Task Handle(DeleteUserCommand command)
        {
            var user = await userRepository.GetByIdAsync(command.UserId);
            if (user != null)
            {
                await userRepository.DeleteAsync(user.UserId);
                await unitOfWork.CompleteAsync();
            }
            else
            {
                Console.WriteLine($"User with id {command.UserId} not found");
                throw new Exception($"User with id {command.UserId} not found");
            }
        }
    }
}