namespace chefstock_platform.UserManagement.Interfaces.REST.Resources;

public record ProfileResource(int ProfileId, int UserId, string? Bio, string? ProfilePicture);