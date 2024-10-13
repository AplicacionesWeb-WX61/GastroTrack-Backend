using chefstock_platform.RestaurantManagement.Domain.Model.Commands;
using chefstock_platform.RestaurantManagement.Domain.Repositories;
using chefstock_platform.RestaurantManagement.Domain.Services;
using chefstock_platform.Shared.Domain.Repositories;
using chefstock_platform.RestaurantManagement.Domain.Model.Entities;

namespace chefstock_platform.RestaurantManagement.Application.Internal.CommandServices;

public class MembrersCommandService(IMembrersRepository membrersRepository, IUnitOfWork unitOfWork) : IMembrersCommandService
{
    public async Task<Membrers?> Handle(CreateMembrersCommand command)
    {
        var employee = new Membrers(command);
        try
        {
            await membrersRepository.AddAsync(employee);
            await unitOfWork.CompleteAsync();
            return employee;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the employee: {e.Message}");
            throw;
        }
    }

    public async Task<Membrers?> Handle(UpdateMembrersCommand command)
    {
        var employee = await membrersRepository.GetByIdAsync(command.MembersId);
        if (employee != null)
        {
            employee.Update(command);
            await membrersRepository.UpdateAsync(employee);
            await unitOfWork.CompleteAsync();
            return employee;
        }
        else
        {
            Console.WriteLine($"Employee with id {command.MembersId} not found");
            throw new Exception($"Employee with id {command.MembersId} not found");
        }
    }

    public async Task Handle(DeleteMembrersCommand command)
    {
        var employee = await membrersRepository.GetByIdAsync(command.MembersId);
        if (employee != null)
        {
            await membrersRepository.DeleteAsync(employee.MembersId);
            await unitOfWork.CompleteAsync();
        }
        else
        {
            Console.WriteLine($"Employee with id {command.MembersId} not found");
            throw new Exception($"Employee with id {command.MembersId} not found");
        }
    }
}