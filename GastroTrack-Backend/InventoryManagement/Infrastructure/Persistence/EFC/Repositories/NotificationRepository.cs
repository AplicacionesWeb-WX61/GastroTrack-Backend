using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Repositories;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace chefstock_platform.InventoryManagement.Infrastructure.Persistence.EFC.Repositories;

public class NotificationRepository(AppDbContext context) : BaseRepository<Notification>(context), INotificationRepository
{
    public async Task<Notification?> GetByIdAsync(int notificationId)
    {
        return await Context.Set<Notification>().FindAsync(notificationId);
    }

    public async Task UpdateAsync(Notification notification)
    {
        Context.Set<Notification>().Update(notification);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int notificationId)
    {
        var notification = await Context.Set<Notification>().FindAsync(notificationId);
        if (notification != null)
        {
            Context.Set<Notification>().Remove(notification);
            await Context.SaveChangesAsync();
        }
    }
}