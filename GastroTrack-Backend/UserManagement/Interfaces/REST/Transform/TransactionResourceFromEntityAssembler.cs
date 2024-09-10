using chefstock_platform.UserManagement.Domain.Model.Entities;
using chefstock_platform.UserManagement.Interfaces.REST.Resources;

namespace chefstock_platform.UserManagement.Interfaces.REST.Transform;

public static class TransactionResourceFromEntityAssembler
{
    public static TransactionResource ToResourceFromEntity(Transaction transaction)
    {
        return new TransactionResource(transaction.TransactionId, transaction.UserId, transaction.ProductId, transaction.TransactionType, transaction.TransactionDate, transaction.Quantity);
    }
}