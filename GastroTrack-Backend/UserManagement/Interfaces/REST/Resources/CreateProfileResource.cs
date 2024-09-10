namespace chefstock_platform.UserManagement.Interfaces.REST.Resources;

public record CreateProfileResource(int UserId, string Bio, string ProfilePicture);