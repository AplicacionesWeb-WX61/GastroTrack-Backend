using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Commands;

namespace chefstock_platform.InventoryManagement.Domain.Services;

public interface IReportCommandService
{
    Task<Report?> Handle(CreateReportCommand command);
    Task<Report?> Handle(UpdateReportCommand command);
    Task Handle(DeleteReportCommand command);
}