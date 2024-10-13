namespace chefstock_platform.RestaurantManagement.Domain.Model.Commands;

public record CreateMembrersCommand(string? MemberName, string? Description, string? Photo, int RoleId);
