using chefstock_platform.RestaurantManagement.Domain.Model.Aggregates;
using chefstock_platform.RestaurantManagement.Domain.Model.Commands;

namespace chefstock_platform.RestaurantManagement.Domain.Model.Entities;

public class Employee
{
    public Employee()
    {

    }
    public Employee(CreateEmployeeCommand command)
    {
        FirstName = command.FirstName;
        LastName = command.LastName;
        Email = command.Email;
        Phone = command.Phone;
        Position = command.Position;
        RestaurantId = command.RestaurantId;
    }
    public void Update(UpdateEmployeeCommand command)
    {
        EmployeeId = command.EmployeeId;
        FirstName = command.FirstName;
        LastName = command.LastName;
        Email = command.Email;
        Phone = command.Phone;
        Position = command.Position;
        RestaurantId = command.RestaurantId;
    }
    public int EmployeeId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Position { get; set; }

    // Foreign key for Restaurant
    public int RestaurantId { get; set; }

    // Navigation property
    public Restaurant? Restaurant { get; set; }
}