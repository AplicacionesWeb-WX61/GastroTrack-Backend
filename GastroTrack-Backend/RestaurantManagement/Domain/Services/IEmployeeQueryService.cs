using chefstock_platform.RestaurantManagement.Domain.Model.Aggregates;
using chefstock_platform.RestaurantManagement.Domain.Model.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;
using chefstock_platform.RestaurantManagement.Domain.Model.Entities;

namespace chefstock_platform.RestaurantManagement.Domain.Services
{
    public interface IEmployeeQueryService
    {
        Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery query);
        Task<Employee?> Handle(GetEmployeeByIdQuery query);
    }
}