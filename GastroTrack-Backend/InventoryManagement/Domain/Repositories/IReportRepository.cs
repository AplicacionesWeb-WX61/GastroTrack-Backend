using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.Shared.Domain.Repositories;

namespace chefstock_platform.InventoryManagement.Domain.Repositories;

public interface IReportRepository:IBaseRepository<Report>
{
    Task<Report?> GetByIdAsync(int reportId);
    Task UpdateAsync(Report report);
    Task DeleteAsync(int id);
}