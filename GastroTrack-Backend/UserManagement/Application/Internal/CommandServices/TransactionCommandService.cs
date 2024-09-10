using chefstock_platform.UserManagement.Domain.Model.Entities;
using chefstock_platform.UserManagement.Domain.Model.Commands;
using chefstock_platform.UserManagement.Domain.Repositories;
using chefstock_platform.UserManagement.Domain.Services;
using chefstock_platform.Shared.Domain.Repositories;
using System;

namespace chefstock_platform.UserManagement.Application.Internal.CommandServices
{
    public class TransactionCommandService(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork)
        : ITransactionCommandService
    {
        public async Task<Transaction?> Handle(CreateTransactionCommand command)
        {
            var transaction = new Transaction(command);
            try
            {
                await transactionRepository.AddAsync(transaction);
                await unitOfWork.CompleteAsync();
                return transaction;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while creating the transaction: {e.Message}");
                throw;
            }
        }

        public async Task<Transaction?> Handle(UpdateTransactionCommand command)
        {
            var transaction = await transactionRepository.GetByIdAsync(command.TransactionId);
            if (transaction != null)
            {
                transaction.Update(command);
                await transactionRepository.UpdateAsync(transaction);
                await unitOfWork.CompleteAsync();
                return transaction;
            }
            else
            {
                Console.WriteLine($"Transaction with id {command.TransactionId} not found");
                throw new Exception($"Transaction with id {command.TransactionId} not found");
            }
        }

        public async Task Handle(DeleteTransactionCommand command)
        {
            var transaction = await transactionRepository.GetByIdAsync(command.TransactionId);
            if (transaction != null)
            {
                await transactionRepository.DeleteAsync(transaction.TransactionId);
                await unitOfWork.CompleteAsync();
            }
            else
            {
                Console.WriteLine($"Transaction with id {command.TransactionId} not found");
                throw new Exception($"Transaction with id {command.TransactionId} not found");
            }
        }
    }
}