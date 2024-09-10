namespace chefstock_platform.UserManagement.Domain.Model.Commands;

public record CreateProfileCommand(int UserId, string Bio, string ProfilePicture);