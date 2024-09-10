using chefstock_platform.RestaurantManagement.Domain.Model.Aggregates;
using chefstock_platform.RestaurantManagement.Domain.Model.Entities;
using chefstock_platform.RestaurantManagement.Domain.Repositories;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace chefstock_platform.RestaurantManagement.Infrastructure.Persistence.EFC.Repositories;

public class EmployeeRepository(AppDbContext context) : BaseRepository<Employee>(context), IEmployeeRepository
{
    public async Task<Employee?> GetByIdAsync(int employeeId)
    {
        return await Context.Set<Employee>().FindAsync(employeeId);
    }

    public async Task UpdateAsync(Employee employee)
    {
        Context.Set<Employee>().Update(employee);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int employeeId)
    {
        var employee = await Context.Set<Employee>().FindAsync(employeeId);
        if (employee != null)
        {
            Context.Set<Employee>().Remove(employee);
            await Context.SaveChangesAsync();
        }
    }
}