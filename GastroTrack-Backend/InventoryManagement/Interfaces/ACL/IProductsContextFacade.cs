﻿using chefstock_platform.InventoryManagement.Domain.Model.Aggregates;

namespace chefstock_platform.InventoryManagement.Interfaces.ACL;

public interface IProductsContextFacade
{
    Task<int> CreateProduct(string name, int stock, string image, string? dateManufacture, string? dueDate, string? state, int categoryId);
    Task<Product?> FetchProductById(int productId);
    Task<IEnumerable<Product>> FetchAllProducts();
    Task UpdateProduct(int productId, string name, int stock, string image, string? dateManufacture, string? dueDate, string? state, int categoryId);
    Task DeleteProduct(int productId);
}