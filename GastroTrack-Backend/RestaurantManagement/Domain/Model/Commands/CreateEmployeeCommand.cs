namespace chefstock_platform.RestaurantManagement.Domain.Model.Commands;

public record CreateEmployeeCommand(string? FirstName, string? LastName, string? Email, string? Phone, string? Position, int RestaurantId);
