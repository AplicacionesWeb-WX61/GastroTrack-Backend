namespace chefstock_platform.InventoryManagement.Domain.Model.Commands;

public record UpdateReportCommand(int ReportId,string ReportName,string? ReportDescription, string? ReportDate);