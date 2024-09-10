namespace chefstock_platform.RestaurantManagement.Domain.Model.Commands;

public record UpdateRestaurantCommand(int RestaurantId, string? Name, string? Location, string? Type);
