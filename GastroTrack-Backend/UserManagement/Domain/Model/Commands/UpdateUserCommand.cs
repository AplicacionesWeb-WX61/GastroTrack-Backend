using chefstock_platform.UserManagement.Domain.Model.ValueObjects;

namespace chefstock_platform.UserManagement.Domain.Model.Commands;

public record UpdateUserCommand(int UserId, string FirstName, string LastName, Email Email, string Password, string Phone, string Address, int RoleId);