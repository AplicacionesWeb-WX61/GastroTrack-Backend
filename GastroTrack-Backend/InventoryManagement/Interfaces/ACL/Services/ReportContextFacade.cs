using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Commands;
using chefstock_platform.InventoryManagement.Domain.Model.Queries;
using chefstock_platform.InventoryManagement.Domain.Services;

namespace chefstock_platform.InventoryManagement.Interfaces.ACL.Services;

public class ReportContextFacade(
    IReportCommandService reportCommandService,
    IReportQueryService reportQueryService)
    : IReportContextFacade
{
    public async Task<int> CreateReport(string reportName,string reportDescription,string reportDate)
    {
        var createReportCommand = new CreateReportCommand(reportName,reportDescription,reportDate);
        var report = await reportCommandService.Handle(createReportCommand);
        return report?.ReportId ?? 0;
    }

    public async Task<Report?> FetchReportById(int id)
    {
        var getReportByIdQuery = new GetReportByIdQuery(id);
        return await reportQueryService.Handle(getReportByIdQuery);
    }

    public async Task<IEnumerable<Report>> FetchAllReport()
    {
        var getAllReportQuery = new GetAllReportQuery();
        return await reportQueryService.Handle(getAllReportQuery);
    }

    public async Task UpdateReport(int id,string reportName,string reportDescription, string reportDate)
    {
        var updateReportCommand = new UpdateReportCommand(id, reportName,reportDescription,reportDate);
        await reportCommandService.Handle(updateReportCommand);
    }

    public async Task DeleteReport(int id)
    {
        var deleteReportCommand = new DeleteReportCommand(id);
        await reportCommandService.Handle(deleteReportCommand);
    }
}