using chefstock_platform.UserManagement.Domain.Model.Commands;

namespace chefstock_platform.UserManagement.Domain.Model.Aggregates;

public class Profile
{
    public Profile()
    {

    }
    public Profile(CreateProfileCommand command)
    {
        UserId = command.UserId;
        Bio = command.Bio;
        ProfilePicture = command.ProfilePicture;
    }
    public void Update(UpdateProfileCommand command)
    {
        ProfileId = command.ProfileId;
        UserId = command.UserId;
        Bio = command.Bio;
        ProfilePicture = command.ProfilePicture;
    }
    public int ProfileId { get; set; }
    public int UserId { get; set; }
    public string? Bio { get; set; }
    public string? ProfilePicture { get; set; }

    // Navigation property
    public User? User { get; set; }
}