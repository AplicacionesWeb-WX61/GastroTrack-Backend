using chefstock_platform.RestaurantManagement.Domain.Model.Commands;
using chefstock_platform.RestaurantManagement.Interfaces.REST.Resources;

namespace chefstock_platform.RestaurantManagement.Interfaces.REST.Transform;

public class CreateEmployeeCommandFromResourceAssembler
{
    public static CreateEmployeeCommand ToCommandFromResource(CreateEmployeeResource resource)
    {
        return new CreateEmployeeCommand(resource.FirstName, resource.LastName, resource.Email, resource.Phone, resource.Position, resource.RestaurantId);
    }
}