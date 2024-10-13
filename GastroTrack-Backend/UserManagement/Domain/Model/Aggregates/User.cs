using chefstock_platform.UserManagement.Domain.Model.Commands;
using chefstock_platform.UserManagement.Domain.Model.Entities;

namespace chefstock_platform.UserManagement.Domain.Model.Aggregates;

public class User
{
    // Constructor por defecto
    public User() {}

        
    public User(CreateUserCommand command)
    {
        FirstName = command.FirstName;
        LastName = command.LastName;
        Email = command.Email; 
        Password = command.Password;
        Company = command.Company;
    }

    // Método para actualizar el usuario
    public void Update(UpdateUserCommand command)
    {
        UserId = command.UserId;
        FirstName = command.FirstName;
        LastName = command.LastName;
        Email = command.Email; // Asegúrate de que esta propiedad sea correcta
        Password = command.Password;
        Company = command.Company;
    }

    // Propiedades del modelo
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; } // Asegúrate de que esta propiedad exista en la base de datos
    public string? Password { get; set; }
    public string? Company { get; set; }
}