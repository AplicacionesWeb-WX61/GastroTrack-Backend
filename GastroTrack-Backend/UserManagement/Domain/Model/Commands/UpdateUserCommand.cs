
namespace chefstock_platform.UserManagement.Domain.Model.Commands;

public record UpdateUserCommand(int UserId, string FirstName, string LastName, String Email, string Password, string Company);