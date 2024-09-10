using chefstock_platform.UserManagement.Domain.Model.Entities;
using chefstock_platform.UserManagement.Domain.Model.Commands;
using chefstock_platform.UserManagement.Domain.Model.Queries;
using chefstock_platform.UserManagement.Domain.Services;

namespace chefstock_platform.UserManagement.Interfaces.ACL.Services
{
    public class TransactionContextFacade(
        ITransactionCommandService transactionCommandService,
        ITransactionQueryService transactionQueryService)
        : ITransactionContextFacade
    {
        public async Task<int> CreateTransaction(int userId, int productId, string transactionType, DateTime transactionDate, int quantity)
        {
            var createTransactionCommand = new CreateTransactionCommand(userId, productId, transactionType, transactionDate, quantity);
            var transaction = await transactionCommandService.Handle(createTransactionCommand);
            return transaction?.TransactionId ?? 0;
        }

        public async Task<Transaction?> FetchTransactionById(int id)
        {
            var getTransactionByIdQuery = new GetTransactionByIdQuery(id);
            return await transactionQueryService.Handle(getTransactionByIdQuery);
        }

        public async Task<IEnumerable<Transaction>> FetchAllTransactions()
        {
            var getAllTransactionsQuery = new GetAllTransactionsQuery();
            return await transactionQueryService.Handle(getAllTransactionsQuery);
        }

        public async Task UpdateTransaction(int transactionId,int userId, int productId, string transactionType, DateTime transactionDate, int quantity)
        {
            var updateTransactionCommand = new UpdateTransactionCommand(transactionId, userId, productId, transactionType, transactionDate, quantity);
            await transactionCommandService.Handle(updateTransactionCommand);
        }

        public async Task DeleteTransaction(int id)
        {
            var deleteTransactionCommand = new DeleteTransactionCommand(id);
            await transactionCommandService.Handle(deleteTransactionCommand);
        }
    }
}