
namespace chefstock_platform.UserManagement.Interfaces.REST.Resources;

public record CreateUserResource(string FirstName, string LastName, string Email, string Password, string Company);