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
public class SupplierController : ControllerBase
{
    private readonly ISupplierCommandService _supplierCommandService;
    private readonly ISupplierQueryService _supplierQueryService;

    public SupplierController(ISupplierCommandService supplierCommandService, ISupplierQueryService supplierQueryService)
    {
        _supplierCommandService = supplierCommandService;
        _supplierQueryService = supplierQueryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSupplier(CreateSupplierResource resource)
    {
        var createSupplierCommand = CreateSupplierCommandFromResourceAssembler.ToCommandFromResource(resource);
        var supplier = await _supplierCommandService.Handle(createSupplierCommand);
        if (supplier is null) return BadRequest();
        var supplierResource = SupplierResourceFromEntityAssembler.ToResourceFromEntity(supplier);
        return CreatedAtAction(nameof(GetSupplierById), new {supplierId = supplierResource.SupplierId}, supplierResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSuppliers()
    {
        var getAllSuppliersQuery = new GetAllSuppliersQuery();
        var suppliers = await _supplierQueryService.Handle(getAllSuppliersQuery);
        var supplierResources = suppliers.Select(SupplierResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(supplierResources);
    }

    [HttpGet("{supplierId:int}")]
    public async Task<IActionResult> GetSupplierById(int supplierId)
    {
        var getSupplierByIdQuery = new GetSupplierByIdQuery(supplierId);
        var supplier = await _supplierQueryService.Handle(getSupplierByIdQuery);
        if (supplier == null) return NotFound();
        var supplierResource = SupplierResourceFromEntityAssembler.ToResourceFromEntity(supplier);
        return Ok(supplierResource);
    }

    [HttpPut("{supplierId:int}")]
    public async Task<IActionResult> UpdateSupplier(int supplierId, UpdateSupplierResource resource)
    {
        var updateSupplierCommand = UpdateSupplierCommandFromResourceAssembler.ToCommandFromResource(resource);
        await _supplierCommandService.Handle(updateSupplierCommand);
        return NoContent();
    }

    [HttpDelete("{supplierId:int}")]
    public async Task<IActionResult> DeleteSupplier(int supplierId)
    {
        var deleteSupplierCommand = new DeleteSupplierCommand(supplierId);
        await _supplierCommandService.Handle(deleteSupplierCommand);
        return NoContent();
    }
}