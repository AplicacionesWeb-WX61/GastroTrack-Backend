using chefstock_platform.UserManagement.Domain.Model.Entities;
using chefstock_platform.UserManagement.Domain.Model.Queries;
using chefstock_platform.UserManagement.Domain.Repositories;
using chefstock_platform.UserManagement.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chefstock_platform.UserManagement.Application.Internal.QueryServices
{
    public class TransactionQueryService(ITransactionRepository transactionRepository) : ITransactionQueryService
    {
        public async Task<IEnumerable<Transaction>> Handle(GetAllTransactionsQuery query)
        {
            return await transactionRepository.ListAsync();
        }

        public async Task<Transaction?> Handle(GetTransactionByIdQuery query)
        {
            return await transactionRepository.GetByIdAsync(query.TransactionId);
        }
    }
}