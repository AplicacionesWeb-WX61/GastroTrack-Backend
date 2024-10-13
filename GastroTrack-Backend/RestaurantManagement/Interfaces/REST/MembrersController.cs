using System.Net.Mime;
using chefstock_platform.RestaurantManagement.Domain.Model.Commands;
using chefstock_platform.RestaurantManagement.Domain.Services;
using chefstock_platform.RestaurantManagement.Interfaces.REST.Resources;
using chefstock_platform.RestaurantManagement.Interfaces.REST.Transform;
using chefstock_platform.RestaurantManagement.Domain.Model.Queries;
using Microsoft.AspNetCore.Mvc;

namespace chefstock_platform.RestaurantManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class MembrersController : ControllerBase // Cambiar a ControllerBase
{
    private readonly IMembrersCommandService membrersCommandService;
    private readonly IMembrersQueryService membrersQueryService;

    public MembrersController(IMembrersCommandService membrersCommandService, IMembrersQueryService membrersQueryService)
    {
        this.membrersCommandService = membrersCommandService;
        this.membrersQueryService = membrersQueryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMembers(CreateMembrersResource resource)
    {
        var createEmployeeCommand = CreateMembrersCommandFromResourceAssembler.ToCommandFromResource(resource);
        var employee = await membrersCommandService.Handle(createEmployeeCommand);
        if (employee is null) return BadRequest();
        
        var employeeResource = MembrersResourceFromEntityAssembler.ToResourceFromEntity(employee);
        return CreatedAtAction(nameof(GetMemberById), new { membersId = employeeResource.MembersId }, employeeResource); // Asegúrate de usar 'membersId'
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMembers()
    {
        var getAllEmployeesQuery = new GetAllMembrersQuery();
        var employees = await membrersQueryService.Handle(getAllEmployeesQuery);
        var employeeResources = employees.Select(MembrersResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(employeeResources);
    }

    [HttpGet("{membersId:int}")]
    public async Task<IActionResult> GetMemberById(int membersId) // Cambiar 'employeeId' a 'membersId'
    {
        var getEmployeeByIdQuery = new GetMembrersByIdQuery(membersId);
        var employee = await membrersQueryService.Handle(getEmployeeByIdQuery);
        if (employee == null) return NotFound();
        
        var employeeResource = MembrersResourceFromEntityAssembler.ToResourceFromEntity(employee);
        return Ok(employeeResource);
    }

    [HttpPut("{membersId:int}")]
    public async Task<IActionResult> UpdateMember(int membersId, UpdateMembrersResource resource)
    {
        var updateEmployeeCommand = UpdateMembrersCommandFromResourceAssembler.ToCommandFromResource(resource);
        await membrersCommandService.Handle(updateEmployeeCommand);
        return NoContent();
    }

    [HttpDelete("{membersId:int}")]
    public async Task<IActionResult> DeleteMember(int membersId)
    {
        var deleteEmployeeCommand = new DeleteMembrersCommand(membersId);
        await membrersCommandService.Handle(deleteEmployeeCommand);
        return NoContent();
    }
}