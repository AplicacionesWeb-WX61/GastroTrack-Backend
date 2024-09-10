using chefstock_platform.UserManagement.Domain.Model.Entities;
using chefstock_platform.UserManagement.Domain.Model.Commands;

namespace chefstock_platform.UserManagement.Domain.Services
{
    public interface ITransactionCommandService
    {
        Task<Transaction?> Handle(CreateTransactionCommand command);
        Task<Transaction?> Handle(UpdateTransactionCommand command);
        Task Handle(DeleteTransactionCommand command);
    }
}