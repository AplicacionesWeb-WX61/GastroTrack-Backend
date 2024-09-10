using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Repositories;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using chefstock_platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace chefstock_platform.InventoryManagement.Infrastructure.Persistence.EFC.Repositories;

public class ProductRepository(AppDbContext context) : BaseRepository<Product>(context), IProductRepository
    {
        public async Task<Product?> GetByIdAsync(int productId)
        {
            return await Context.Set<Product>().FindAsync(productId);
        }

        public async Task UpdateAsync(Product product)
        {
            Context.Set<Product>().Update(product);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int productId)
        {
            var product = await Context.Set<Product>().FindAsync(productId);
            if (product != null)
            {
                Context.Set<Product>().Remove(product);
                await Context.SaveChangesAsync();
            }
        }
    }
