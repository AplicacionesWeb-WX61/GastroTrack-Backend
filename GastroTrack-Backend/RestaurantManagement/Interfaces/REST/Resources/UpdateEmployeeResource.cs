namespace chefstock_platform.RestaurantManagement.Interfaces.REST.Resources;

public record UpdateEmployeeResource(int EmployeeId, string FirstName, string LastName, string Email, string Phone, string Position, int RestaurantId);
