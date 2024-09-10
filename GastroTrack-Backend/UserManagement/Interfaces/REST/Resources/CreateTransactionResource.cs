namespace chefstock_platform.UserManagement.Interfaces.REST.Resources;

public record CreateTransactionResource(int UserId, int ProductId, string TransactionType, DateTime TransactionDate, int Quantity);