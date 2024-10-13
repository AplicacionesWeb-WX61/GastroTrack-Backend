
namespace chefstock_platform.UserManagement.Domain.Model.Commands;

public record CreateUserCommand(string FirstName, string LastName, String Email, string Password, string Company);