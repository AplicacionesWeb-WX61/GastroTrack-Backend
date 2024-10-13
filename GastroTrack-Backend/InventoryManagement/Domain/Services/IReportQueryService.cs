using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Queries;

namespace chefstock_platform.InventoryManagement.Domain.Services;

public interface IReportQueryService
{
    Task<IEnumerable<Report>> Handle(GetAllReportQuery query);
    Task<Report?> Handle(GetReportByIdQuery query);
}