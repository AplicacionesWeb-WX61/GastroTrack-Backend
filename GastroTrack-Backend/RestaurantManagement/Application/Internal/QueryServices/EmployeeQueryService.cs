using chefstock_platform.RestaurantManagement.Domain.Model.Aggregates;
using chefstock_platform.RestaurantManagement.Domain.Repositories;
using chefstock_platform.RestaurantManagement.Domain.Services;
using chefstock_platform.RestaurantManagement.Domain.Model.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;
using chefstock_platform.RestaurantManagement.Domain.Model.Entities;

namespace chefstock_platform.RestaurantManagement.Application.Internal.QueryServices;

public class EmployeeQueryService(IEmployeeRepository employeeRepository) : IEmployeeQueryService
{
    public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery query)
    {
        return await employeeRepository.ListAsync();
    }

    public async Task<Employee?> Handle(GetEmployeeByIdQuery query)
    {
        return await employeeRepository.GetByIdAsync(query.EmployeeId);
    }
}