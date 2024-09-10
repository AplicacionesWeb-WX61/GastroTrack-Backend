using chefstock_platform.UserManagement.Domain.Model.Commands;
using chefstock_platform.UserManagement.Interfaces.REST.Resources;

namespace chefstock_platform.UserManagement.Interfaces.REST.Transform;

public class CreateTransactionCommandFromResourceAssembler
{
    public static CreateTransactionCommand ToCommandFromResource(CreateTransactionResource resource)
    {
        return new CreateTransactionCommand(resource.UserId, resource.ProductId, resource.TransactionType, resource.TransactionDate, resource.Quantity);
    }
}