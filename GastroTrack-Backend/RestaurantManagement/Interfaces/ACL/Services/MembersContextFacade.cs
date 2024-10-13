using chefstock_platform.RestaurantManagement.Domain.Model.Commands;
using chefstock_platform.RestaurantManagement.Domain.Model.Entities;
using chefstock_platform.RestaurantManagement.Domain.Model.Queries;
using chefstock_platform.RestaurantManagement.Domain.Services;

namespace chefstock_platform.RestaurantManagement.Interfaces.ACL.Services
{
    public class MembersContextFacade(
        IMembrersCommandService membrersCommandService,
        IMembrersQueryService membrersQueryService)
        : IMembersContextFacade
    {
        public async Task<int> CreateEmployee(string memberName, string description, string photo, int roleId)
        {
            var createEmployeeCommand = new CreateMembrersCommand(memberName, description, photo, roleId);
            var employee = await membrersCommandService.Handle(createEmployeeCommand);
            return employee?.MembersId ?? 0;
        }

        public async Task<Membrers?> FetchEmployeeById(int id)
        {
            var getEmployeeByIdQuery = new GetMembrersByIdQuery(id);
            return await membrersQueryService.Handle(getEmployeeByIdQuery);
        }

        public async Task<IEnumerable<Membrers>> FetchAllEmployees()
        {
            var getAllEmployeesQuery = new GetAllMembrersQuery();
            return await membrersQueryService.Handle(getAllEmployeesQuery);
        }

        public async Task UpdateEmployee(int id, string memberName, string description, string photo, int RoleId)
        {
            var updateEmployeeCommand = new UpdateMembrersCommand(id, memberName, description, photo, RoleId);
            await membrersCommandService.Handle(updateEmployeeCommand);
        }

        public async Task DeleteEmployee(int id)
        {
            var deleteEmployeeCommand = new DeleteMembrersCommand(id);
            await membrersCommandService.Handle(deleteEmployeeCommand);
        }
    }
}