namespace chefstock_platform.InventoryManagement.Domain.Model.Commands;

public record CreateReportCommand(string ReportName,string? ReportDescription, string? ReportDate);