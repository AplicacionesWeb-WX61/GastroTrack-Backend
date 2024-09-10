namespace chefstock_platform.RestaurantManagement.Domain.Model.Commands;

public record UpdateEmployeeCommand(int EmployeeId, string? FirstName, string? LastName, string? Email, string? Phone, string? Position, int RestaurantId);