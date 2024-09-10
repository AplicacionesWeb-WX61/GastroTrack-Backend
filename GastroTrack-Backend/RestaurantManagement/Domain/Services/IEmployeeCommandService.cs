using chefstock_platform.RestaurantManagement.Domain.Model.Aggregates;
using chefstock_platform.RestaurantManagement.Domain.Model.Commands;
using chefstock_platform.RestaurantManagement.Domain.Model.Entities;

namespace chefstock_platform.RestaurantManagement.Domain.Services;

public interface IEmployeeCommandService
{
    Task<Employee?> Handle(CreateEmployeeCommand command);
    Task<Employee?> Handle(UpdateEmployeeCommand command);
    Task Handle(DeleteEmployeeCommand command);
}