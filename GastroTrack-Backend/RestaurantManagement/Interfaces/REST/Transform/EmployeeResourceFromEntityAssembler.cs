using chefstock_platform.RestaurantManagement.Domain.Model.Entities;
using chefstock_platform.RestaurantManagement.Interfaces.REST.Resources;

namespace chefstock_platform.RestaurantManagement.Interfaces.REST.Transform;

public static class EmployeeResourceFromEntityAssembler
{
    public static EmployeeResource ToResourceFromEntity(Employee employee)
    {
        return new EmployeeResource(employee.EmployeeId, employee.FirstName, employee.LastName, employee.Email, employee.Phone, employee.Position, employee.RestaurantId);
    }
}