using chefstock_platform.UserManagement.Domain.Model.Entities;

namespace chefstock_platform.UserManagement.Interfaces.ACL
{
    public interface ITransactionContextFacade
    {
        Task<int> CreateTransaction(int userId, int productId, string transactionType, DateTime transactionDate, int quantity);
        Task<Transaction?> FetchTransactionById(int id);
        Task<IEnumerable<Transaction>> FetchAllTransactions();
        Task UpdateTransaction(int transactionId, int userId, int productId, string transactionType, DateTime transactionDate, int quantity);
        Task DeleteTransaction(int id);
    }
}