namespace chefstock_platform.UserManagement.Domain.Model.Commands;

public record CreateTransactionCommand(int UserId, int ProductId, string TransactionType, DateTime TransactionDate, int Quantity);