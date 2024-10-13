
namespace chefstock_platform.UserManagement.Interfaces.REST.Resources;

public record UpdateUserResource(int UserId, string FirstName, string LastName, string Email, string Password, string Company);