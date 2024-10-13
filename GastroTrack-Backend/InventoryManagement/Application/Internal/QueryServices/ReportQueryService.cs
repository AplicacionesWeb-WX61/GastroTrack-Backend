using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Queries;
using chefstock_platform.InventoryManagement.Domain.Repositories;
using chefstock_platform.InventoryManagement.Domain.Services;

namespace chefstock_platform.InventoryManagement.Application.Internal.QueryServices;

public class ReportQueryService(IReportRepository reportRepository) : IReportQueryService
{
    public async Task<IEnumerable<Report>> Handle(GetAllReportQuery query)
    {
        return await reportRepository.ListAsync();
    }

    public async Task<Report?> Handle(GetReportByIdQuery query)
    {
        return await reportRepository.FindByIdAsync(query.ReportId);
    }
}