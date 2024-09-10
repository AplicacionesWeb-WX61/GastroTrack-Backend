namespace chefstock_platform.RestaurantManagement.Domain.Model.Commands;

public record CreateRestaurantCommand(string? Name, string? Location, string? Type);
