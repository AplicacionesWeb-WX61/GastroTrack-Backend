using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Repositories;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace chefstock_platform.InventoryManagement.Infrastructure.Persistence.EFC.Repositories;

public class ReportRepository(AppDbContext context) : BaseRepository<Report>(context), IReportRepository
{
    public async Task<Report?> GetByIdAsync(int reportId)
    {
        return await Context.Set<Report>().FindAsync(reportId);
    }

    public async Task UpdateAsync(Report report)
    {
        Context.Set<Report>().Update(report);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int reportId)
    {
        var report = await Context.Set<Report>().FindAsync(reportId);
        if (report != null)
        {
            Context.Set<Report>().Remove(report);
            await Context.SaveChangesAsync();
        }
    }
}