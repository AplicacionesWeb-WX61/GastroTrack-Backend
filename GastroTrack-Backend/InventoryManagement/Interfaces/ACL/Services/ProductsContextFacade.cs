using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;
using chefstock_platform.InventoryManagement.Domain.Model.Commands;
using chefstock_platform.InventoryManagement.Domain.Model.Queries;
using chefstock_platform.InventoryManagement.Domain.Services;

namespace chefstock_platform.InventoryManagement.Interfaces.ACL.Services;

public class ProductsContextFacade(
    IProductCommandService productCommandService,
    IProductQueryService productQueryService)
    : IProductsContextFacade
{
    public async Task<int> CreateProduct(string name, int stock, string image, string description, DateTime dueDate, int categoryId)
    {
        var createProductCommand = new CreateProductCommand(name, stock, image, description, dueDate, categoryId);
        var product = await productCommandService.Handle(createProductCommand);
        return product?.ProductId ?? 0;
    }

    public async Task<Product?> FetchProductById(int id)
    {
        var getProductByIdQuery = new GetProductByIdQuery(id);
        return await productQueryService.Handle(getProductByIdQuery);
    }

    public async Task<IEnumerable<Product>> FetchAllProducts()
    {
        var getAllProductsQuery = new GetAllProductsQuery();
        return await productQueryService.Handle(getAllProductsQuery);
    }

    public async Task UpdateProduct(int id, string name, int stock, string image, string description, DateTime dueDate, int categoryId)
    {
        var updateProductCommand = new UpdateProductCommand(id, name, stock, image, description, dueDate, categoryId);
        await productCommandService.Handle(updateProductCommand);
    }
    public async Task DeleteProduct(int id)
    {
        var deleteProductCommand = new DeleteProductCommand(id);
        await productCommandService.Handle(deleteProductCommand);
    }
}