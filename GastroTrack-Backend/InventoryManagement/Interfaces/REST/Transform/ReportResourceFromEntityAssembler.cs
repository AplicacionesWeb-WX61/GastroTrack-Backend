using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Interfaces.REST.Resources;

namespace chefstock_platform.InventoryManagement.Interfaces.REST.Transform;

public static class ReportResourceFromEntityAssembler
{
    public static ReportResource ToResourceFromEntity(Report entity)
    {
        return new ReportResource(entity.ReportId, entity.ReportName, entity.ReportDescription,entity.ReportDate);
    }
}