namespace chefstock_platform.UserManagement.Domain.Model.Commands;

public record UpdateProfileCommand(int ProfileId, int UserId, string Bio, string ProfilePicture);