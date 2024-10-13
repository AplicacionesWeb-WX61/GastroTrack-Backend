using chefstock_platform.InventoryManagement.Domain.Model.Commands;
using chefstock_platform.InventoryManagement.Interfaces.REST.Resources;

namespace chefstock_platform.InventoryManagement.Interfaces.REST.Transform;

public static class UpdateReportCommandFromResourceAssembler
{
    public static UpdateReportCommand ToCommandFromResource(UpdateReportResource resource)
    {
        return new UpdateReportCommand(resource.ReportId, resource.ReportName, resource.ReportDescription, resource.ReportDate);
    }
}