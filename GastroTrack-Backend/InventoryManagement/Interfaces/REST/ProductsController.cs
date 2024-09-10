using System.Net.Mime;
using chefstock_platform.InventoryManagement.Domain.Model.Commands;
using chefstock_platform.InventoryManagement.Domain.Model.Queries;
using chefstock_platform.InventoryManagement.Domain.Services;
using chefstock_platform.InventoryManagement.Interfaces.REST.Resources;
using chefstock_platform.InventoryManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace chefstock_platform.InventoryManagement.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ProductsController(IProductCommandService productCommandService, IProductQueryService productQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductResource resource)
    {
        var createProductCommand = CreateProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        var product = await productCommandService.Handle(createProductCommand);
        if (product is null) return BadRequest();
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return CreatedAtAction(nameof(GetProductById), new {productId = productResource.ProductId}, productResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var getAllProductsQuery = new GetAllProductsQuery();
        var products = await productQueryService.Handle(getAllProductsQuery);
        var productResources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(productResources);
    }

    [HttpGet("{productId:int}")]
    public async Task<IActionResult> GetProductById(int productId)
    {
        var getProductByIdQuery = new GetProductByIdQuery(productId);
        var product = await productQueryService.Handle(getProductByIdQuery);
        if (product == null) return NotFound();
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return Ok(productResource);
    }

    [HttpPut("{productId:int}")]
    public async Task<IActionResult> UpdateProduct(int id, UpdateProductResource resource)
    {
        var updateProductCommand = UpdateProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        await productCommandService.Handle(updateProductCommand);
        return NoContent();
    }

    [HttpDelete("{productId:int}")]
    public async Task<IActionResult> DeleteProduct(int productId)
    {
        var deleteProductCommand = new DeleteProductCommand(productId);
        await productCommandService.Handle(deleteProductCommand);
        return NoContent();
    }
}