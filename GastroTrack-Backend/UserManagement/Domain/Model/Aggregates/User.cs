using chefstock_platform.UserManagement.Domain.Model.Commands;
using chefstock_platform.UserManagement.Domain.Model.Entities;
using chefstock_platform.UserManagement.Domain.Model.ValueObjects;

namespace chefstock_platform.UserManagement.Domain.Model.Aggregates;

public class User
{
    public User()
    {

    }
    public User(CreateUserCommand command)
    {
        FirstName = command.FirstName;
        LastName = command.LastName;
        Email = command.Email;
        Password = command.Password;
        Phone = command.Phone;
        Address = command.Address;
        RoleId = command.RoleId;
    }
    public void Update(UpdateUserCommand command)
    {
        UserId = command.UserId;
        FirstName = command.FirstName;
        LastName = command.LastName;
        Email = command.Email;
        Password = command.Password;
        Phone = command.Phone;
        Address = command.Address;
        RoleId = command.RoleId;
    }
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Email? Email { get; set; }
    public string? Password { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public int RoleId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastLogin { get; set; }

    // Navigation property
    public Role? Role { get; set; }

    // Navigation property
    public Profile? Profile { get; set; }

    // Navigation property
    public ICollection<Transaction>? Transactions { get; set; }
}