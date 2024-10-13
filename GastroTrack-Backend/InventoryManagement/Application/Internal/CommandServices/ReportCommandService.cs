using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Commands;
using chefstock_platform.InventoryManagement.Domain.Repositories;
using chefstock_platform.InventoryManagement.Domain.Services;
using chefstock_platform.Shared.Domain.Repositories;

namespace chefstock_platform.InventoryManagement.Application.Internal.CommandServices;

public class ReportCommandService(IReportRepository reportRepository, IUnitOfWork unitOfWork) : IReportCommandService
{
    public async Task<Report?> Handle(CreateReportCommand command) 
    {
        var report = new Report(command);
        try
        {
            await reportRepository.AddAsync(report);
            await unitOfWork.CompleteAsync();
            return report;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the product: {e.Message}");
            throw;
        }
    }
    
    public async Task<Report?> Handle(UpdateReportCommand command)
    {
        var report = await reportRepository.GetByIdAsync(command.ReportId);
        if (report != null)
        {
            report.Update(command);
            await reportRepository.UpdateAsync(report);
            await unitOfWork.CompleteAsync();
            return report;
        }
        else
        {
            Console.WriteLine($"Product with id {command.ReportId} not found");
            throw new Exception($"Product with id {command.ReportId} not found");
        }
    }
    
    public async Task Handle(DeleteReportCommand command)
    {
        var report = await reportRepository.GetByIdAsync(command.ReportId);
        if (report != null)
        {
            await reportRepository.DeleteAsync(report.ReportId);
            await unitOfWork.CompleteAsync();
        }
        else
        {
            Console.WriteLine($"Product with id {command.ReportId} not found");
            throw new Exception($"Product with id {command.ReportId} not found"); 
        }
    }
}