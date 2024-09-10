using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Model.Commands;
using chefstock_platform.UserManagement.Domain.Repositories;
using chefstock_platform.UserManagement.Domain.Services;
using chefstock_platform.Shared.Domain.Repositories;
using System;

namespace chefstock_platform.UserManagement.Application.Internal.CommandServices
{
    public class RoleCommandService(IRoleRepository roleRepository, IUnitOfWork unitOfWork) : IRoleCommandService
    {
        public async Task<Role?> Handle(CreateRoleCommand command)
        {
            var role = new Role(command);
            try
            {
                await roleRepository.AddAsync(role);
                await unitOfWork.CompleteAsync();
                return role;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while creating the role: {e.Message}");
                throw;
            }
        }

        public async Task<Role?> Handle(UpdateRoleCommand command)
        {
            var role = await roleRepository.GetByIdAsync(command.RoleId);
            if (role != null)
            {
                role.Update(command);
                await roleRepository.UpdateAsync(role);
                await unitOfWork.CompleteAsync();
                return role;
            }
            else
            {
                Console.WriteLine($"Role with id {command.RoleId} not found");
                throw new Exception($"Role with id {command.RoleId} not found");
            }
        }

        public async Task Handle(DeleteRoleCommand command)
        {
            var role = await roleRepository.GetByIdAsync(command.RoleId);
            if (role != null)
            {
                await roleRepository.DeleteAsync(role.RoleId);
                await unitOfWork.CompleteAsync();
            }
            else
            {
                Console.WriteLine($"Role with id {command.RoleId} not found");
                throw new Exception($"Role with id {command.RoleId} not found");
            }
        }
    }
}