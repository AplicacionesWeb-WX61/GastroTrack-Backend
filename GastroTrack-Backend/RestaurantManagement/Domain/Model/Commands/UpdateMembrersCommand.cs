namespace chefstock_platform.RestaurantManagement.Domain.Model.Commands;

public record UpdateMembrersCommand(int MembersId,string? MemberName, string? Description, string? Photo, int RoleId);