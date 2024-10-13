namespace chefstock_platform.RestaurantManagement.Interfaces.REST.Resources;

public record CreateMembrersResource(string MemberName, string Description, string Photo, int RoleId);