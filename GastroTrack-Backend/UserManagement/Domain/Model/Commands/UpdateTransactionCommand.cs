namespace chefstock_platform.UserManagement.Domain.Model.Commands;

public record UpdateTransactionCommand(int TransactionId, int UserId, int ProductId, string TransactionType, DateTime TransactionDate, int Quantity);