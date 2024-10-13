namespace chefstock_platform.RestaurantManagement.Interfaces.REST.Resources;

public record UpdateMembrersResource(int MembersId, string MemberName, string Description, string Photo, int RoleId);
