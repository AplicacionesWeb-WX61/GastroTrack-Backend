using chefstock_platform.RestaurantManagement.Domain.Model.Commands;
using chefstock_platform.RestaurantManagement.Domain.Model.Entities;
using chefstock_platform.RestaurantManagement.Domain.Model.Queries;
using chefstock_platform.RestaurantManagement.Domain.Services;

namespace chefstock_platform.RestaurantManagement.Interfaces.ACL.Services
{
    public class EmployeeContextFacade(
        IEmployeeCommandService employeeCommandService,
        IEmployeeQueryService employeeQueryService)
        : IEmployeeContextFacade
    {
        public async Task<int> CreateEmployee(string firstName, string lastName, string email, string phone, string position, int restaurantId)
        {
            var createEmployeeCommand = new CreateEmployeeCommand(firstName, lastName, email, phone, position, restaurantId);
            var employee = await employeeCommandService.Handle(createEmployeeCommand);
            return employee?.EmployeeId ?? 0;
        }

        public async Task<Employee?> FetchEmployeeById(int id)
        {
            var getEmployeeByIdQuery = new GetEmployeeByIdQuery(id);
            return await employeeQueryService.Handle(getEmployeeByIdQuery);
        }

        public async Task<IEnumerable<Employee>> FetchAllEmployees()
        {
            var getAllEmployeesQuery = new GetAllEmployeesQuery();
            return await employeeQueryService.Handle(getAllEmployeesQuery);
        }

        public async Task UpdateEmployee(int id, string firstName, string lastName, string email, string phone, string position, int restaurantId)
        {
            var updateEmployeeCommand = new UpdateEmployeeCommand(id, firstName, lastName, email, phone, position, restaurantId);
            await employeeCommandService.Handle(updateEmployeeCommand);
        }

        public async Task DeleteEmployee(int id)
        {
            var deleteEmployeeCommand = new DeleteEmployeeCommand(id);
            await employeeCommandService.Handle(deleteEmployeeCommand);
        }
    }
}