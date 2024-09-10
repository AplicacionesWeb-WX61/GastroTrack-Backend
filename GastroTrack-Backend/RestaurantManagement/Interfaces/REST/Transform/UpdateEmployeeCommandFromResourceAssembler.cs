using chefstock_platform.RestaurantManagement.Domain.Model.Commands;
using chefstock_platform.RestaurantManagement.Interfaces.REST.Resources;

namespace chefstock_platform.RestaurantManagement.Interfaces.REST.Transform;

public static class UpdateEmployeeCommandFromResourceAssembler
{
    public static UpdateEmployeeCommand ToCommandFromResource(UpdateEmployeeResource resource)
    {
        return new UpdateEmployeeCommand(resource.EmployeeId, resource.FirstName, resource.LastName, resource.Email, resource.Phone, resource.Position, resource.RestaurantId);
    }
}