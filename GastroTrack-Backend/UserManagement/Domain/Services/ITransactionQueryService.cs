using chefstock_platform.UserManagement.Domain.Model.Entities;
using chefstock_platform.UserManagement.Domain.Model.Queries;


namespace chefstock_platform.UserManagement.Domain.Services
{
    public interface ITransactionQueryService
    {
        Task<IEnumerable<Transaction>> Handle(GetAllTransactionsQuery query);
        Task<Transaction?> Handle(GetTransactionByIdQuery query);
    }
}