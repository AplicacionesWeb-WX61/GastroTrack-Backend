using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;

namespace chefstock_platform.InventoryManagement.Interfaces.ACL;

public interface IReportContextFacade
{
    Task<int> CreateReport(string reportName,string reportDescription, string reportDate);
    Task<Report?> FetchReportById(int reportId);
    Task<IEnumerable<Report>> FetchAllReport();
    Task UpdateReport(int reportId, string reportName,string? reportDescription, string reportDate);
    Task DeleteReport(int reportId);
}