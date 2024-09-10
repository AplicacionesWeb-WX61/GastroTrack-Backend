using chefstock_platform.RestaurantManagement.Domain.Model.Commands;
using chefstock_platform.RestaurantManagement.Domain.Repositories;
using chefstock_platform.RestaurantManagement.Domain.Services;
using chefstock_platform.Shared.Domain.Repositories;
using chefstock_platform.RestaurantManagement.Domain.Model.Entities;

namespace chefstock_platform.RestaurantManagement.Application.Internal.CommandServices;

public class EmployeeCommandService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork) : IEmployeeCommandService
{
    public async Task<Employee?> Handle(CreateEmployeeCommand command)
    {
        var employee = new Employee(command);
        try
        {
            await employeeRepository.AddAsync(employee);
            await unitOfWork.CompleteAsync();
            return employee;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the employee: {e.Message}");
            throw;
        }
    }

    public async Task<Employee?> Handle(UpdateEmployeeCommand command)
    {
        var employee = await employeeRepository.GetByIdAsync(command.EmployeeId);
        if (employee != null)
        {
            employee.Update(command);
            await employeeRepository.UpdateAsync(employee);
            await unitOfWork.CompleteAsync();
            return employee;
        }
        else
        {
            Console.WriteLine($"Employee with id {command.EmployeeId} not found");
            throw new Exception($"Employee with id {command.EmployeeId} not found");
        }
    }

    public async Task Handle(DeleteEmployeeCommand command)
    {
        var employee = await employeeRepository.GetByIdAsync(command.EmployeeId);
        if (employee != null)
        {
            await employeeRepository.DeleteAsync(employee.EmployeeId);
            await unitOfWork.CompleteAsync();
        }
        else
        {
            Console.WriteLine($"Employee with id {command.EmployeeId} not found");
            throw new Exception($"Employee with id {command.EmployeeId} not found");
        }
    }
}