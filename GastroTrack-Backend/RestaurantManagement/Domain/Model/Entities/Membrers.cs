using chefstock_platform.RestaurantManagement.Domain.Model.Commands;
using chefstock_platform.UserManagement.Domain.Model.Aggregates;

namespace chefstock_platform.RestaurantManagement.Domain.Model.Entities;

public class Membrers
{
    public Membrers() { }

    public Membrers(CreateMembrersCommand command)
    {
        MemberName = command.MemberName;
        Description = command.Description;
        Photo = command.Photo;
        RoleId = command.RoleId; // Relación con Role
    }

    public void Update(UpdateMembrersCommand command)
    {
        MembersId = command.MembersId;
        MemberName = command.MemberName;
        Description = command.Description;
        Photo = command.Photo;
        RoleId = command.RoleId; // Relación con Role
    }

 
    public int MembersId { get; set; }  
    public string MemberName { get; set; }  
    public string Description { get; set; }  
    public string Photo { get; set; }  

    // Foreign key para Role
    public int RoleId { get; set; }

    // Propiedad de navegación para Role
    public Role? Role { get; set; }
}