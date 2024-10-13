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
public class ReportController(IReportCommandService reportCommandService, IReportQueryService reportQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateReport(CreateReportResource resource)
    {
        var createReportCommand = CreateReportCommandFromResourceAssembler.ToCommandFromResource(resource);
        var report = await reportCommandService.Handle(createReportCommand);
        if (report is null) return BadRequest();
        var reportResource = ReportResourceFromEntityAssembler.ToResourceFromEntity(report);
        return CreatedAtAction(nameof(GetReportById), new {reportId = reportResource.ReportId}, reportResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllReport()
    {
        var getAllReportQuery = new GetAllReportQuery();
        var report = await reportQueryService.Handle(getAllReportQuery);
        var reportResources = report.Select(ReportResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(reportResources);
    }

    [HttpGet("{reportId:int}")]
    public async Task<IActionResult> GetReportById(int reportId)
    {
        var getReportByIdQuery = new GetReportByIdQuery(reportId);
        var report = await reportQueryService.Handle(getReportByIdQuery);
        if (report == null) return NotFound();
        var reportResource = ReportResourceFromEntityAssembler.ToResourceFromEntity(report);
        return Ok(reportResource);
    }

    [HttpPut("{reportId:int}")]
    public async Task<IActionResult> UpdateReport(int id, UpdateReportResource resource)
    {
        var updateReportCommand = UpdateReportCommandFromResourceAssembler.ToCommandFromResource(resource);
        await reportCommandService.Handle(updateReportCommand);
        return NoContent();
    }

    [HttpDelete("{productId:int}")]
    public async Task<IActionResult> DeleteReport(int reportId)
    {
        var deleteReportCommand = new DeleteReportCommand(reportId);
        await reportCommandService.Handle(deleteReportCommand);
        return NoContent();
    }
}