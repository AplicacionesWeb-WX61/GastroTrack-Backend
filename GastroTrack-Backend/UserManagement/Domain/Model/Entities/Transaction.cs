using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Model.Aggregates;
using chefstock_platform.UserManagement.Domain.Model.Commands;

namespace chefstock_platform.UserManagement.Domain.Model.Entities;

public class Transaction
{
    public Transaction()
    {

    }
    public Transaction(CreateTransactionCommand command)
    {
        UserId = command.UserId;
        ProductId = command.ProductId;
        TransactionType = command.TransactionType;
        TransactionDate = command.TransactionDate;
        Quantity = command.Quantity;
    }
    public void Update(UpdateTransactionCommand command)
    {
        TransactionId = command.TransactionId;
        UserId = command.UserId;
        ProductId = command.ProductId;
        TransactionType = command.TransactionType;
        TransactionDate = command.TransactionDate;
        Quantity = command.Quantity;
    }
    public int TransactionId { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public string? TransactionType { get; set; }
    public DateTime TransactionDate { get; set; }
    public int Quantity { get; set; }

    // Navigation property
    public User? User { get; set; }

    // Navigation property
    public Product? Product { get; set; }
}