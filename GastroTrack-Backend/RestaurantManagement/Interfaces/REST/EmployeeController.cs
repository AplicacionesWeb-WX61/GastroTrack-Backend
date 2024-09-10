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
public class EmployeeController(
    IEmployeeCommandService employeeCommandService,
    IEmployeeQueryService employeeQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateEmployee(CreateEmployeeResource resource)
    {
        var createEmployeeCommand = CreateEmployeeCommandFromResourceAssembler.ToCommandFromResource(resource);
        var employee = await employeeCommandService.Handle(createEmployeeCommand);
        if (employee is null) return BadRequest();
        var employeeResource = EmployeeResourceFromEntityAssembler.ToResourceFromEntity(employee);
        return CreatedAtAction(nameof(GetEmployeeById), new {employeeId = employeeResource.EmployeeId}, employeeResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        var getAllEmployeesQuery = new GetAllEmployeesQuery();
        var employees = await employeeQueryService.Handle(getAllEmployeesQuery);
        var employeeResources = employees.Select(EmployeeResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(employeeResources);
    }

    [HttpGet("{employeeId:int}")]
    public async Task<IActionResult> GetEmployeeById(int employeeId)
    {
        var getEmployeeByIdQuery = new GetEmployeeByIdQuery(employeeId);
        var employee = await employeeQueryService.Handle(getEmployeeByIdQuery);
        if (employee == null) return NotFound();
        var employeeResource = EmployeeResourceFromEntityAssembler.ToResourceFromEntity(employee);
        return Ok(employeeResource);
    }

    [HttpPut("{employeeId:int}")]
    public async Task<IActionResult> UpdateEmployee(int employeeId, UpdateEmployeeResource resource)
    {
        var updateEmployeeCommand = UpdateEmployeeCommandFromResourceAssembler.ToCommandFromResource(resource);
        await employeeCommandService.Handle(updateEmployeeCommand);
        return NoContent();
    }

    [HttpDelete("{employeeId:int}")]
    public async Task<IActionResult> DeleteEmployee(int employeeId)
    {
        var deleteEmployeeCommand = new DeleteEmployeeCommand(employeeId);
        await employeeCommandService.Handle(deleteEmployeeCommand);
        return NoContent();
    }
}