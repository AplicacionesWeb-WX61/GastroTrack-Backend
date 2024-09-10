using chefstock_platform.UserManagement.Domain.Model.Commands;
using chefstock_platform.UserManagement.Interfaces.REST.Resources;

namespace chefstock_platform.UserManagement.Interfaces.REST.Transform;

public class UpdateTransactionCommandFromResourceAssembler
{
    public static UpdateTransactionCommand ToCommandFromResource(UpdateTransactionResource resource)
    {
        return new UpdateTransactionCommand(resource.TransactionId, resource.UserId, resource.ProductId, resource.TransactionType, resource.TransactionDate, resource.Quantity);
    }
}