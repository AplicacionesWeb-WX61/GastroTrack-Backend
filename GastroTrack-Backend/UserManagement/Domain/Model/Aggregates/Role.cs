using chefstock_platform.UserManagement.Domain.Model.Commands;

namespace chefstock_platform.UserManagement.Domain.Model.Aggregates;

public class Role
{
    public Role()
    {

    }
    public Role(CreateRoleCommand command)
    {
        RoleName = command.RoleName;
    }
    public void Update(UpdateRoleCommand command)
    {
        
        RoleId = command.RoleId;
        RoleName = command.RoleName;
    }
    public int RoleId { get; set; }
    public string? RoleName { get; set; }

    // Navigation property
    public ICollection<User>? Users { get; set; }
}