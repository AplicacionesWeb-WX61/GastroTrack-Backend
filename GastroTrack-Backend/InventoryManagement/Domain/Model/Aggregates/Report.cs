using chefstock_platform.InventoryManagement.Domain.Model.Commands;

namespace chefstock_platform.InventoryManagement.Domain.Model.Aggregates;

public class Report
{
    public int ReportId { get; set; }
    
    public string? ReportName { get; set; }
    
    public string? ReportDescription{ get; set; }
    
    public string? ReportDate { get; set; }

    public Report()
    {
        
    }
    
    public Report(int reportId, string reportName,string? reportDescription, string? reportDate)
    {
        ReportId = reportId;
        ReportName = reportName;
        ReportDescription = reportDescription;
        ReportDate = reportDate;
    }

    
    public Report(CreateReportCommand command)
    {
        ReportName = command.ReportName;
        ReportDescription = command.ReportDescription; 
        ReportDate = command.ReportDate; 
    }

    // Método para actualizar el producto
    public void Update(UpdateReportCommand command)
    {
        ReportId = command.ReportId;
        ReportName = command.ReportName;
        ReportDescription = command.ReportDescription; 
        ReportDate = command.ReportDate; 
    }
}