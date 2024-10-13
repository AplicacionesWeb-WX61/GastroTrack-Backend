namespace chefstock_platform.InventoryManagement.Interfaces.REST.Resources;

public record UpdateReportResource(int ReportId, string ReportName,string ReportDescription, string ReportDate);