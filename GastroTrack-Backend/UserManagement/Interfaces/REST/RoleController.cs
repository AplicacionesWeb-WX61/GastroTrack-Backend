using System.Net.Mime;
using chefstock_platform.UserManagement.Domain.Model.Commands;
using chefstock_platform.UserManagement.Domain.Services;
using chefstock_platform.UserManagement.Interfaces.REST.Resources;
using chefstock_platform.UserManagement.Interfaces.REST.Transform;
using chefstock_platform.UserManagement.Domain.Model.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace chefstock_platform.UserManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class RoleController(IRoleCommandService roleCommandService, IRoleQueryService roleQueryService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateRole(CreateRoleResource resource)
    {
        var createRoleCommand = CreateRoleCommandFromResourceAssembler.ToCommandFromResource(resource);
        var role = await roleCommandService.Handle(createRoleCommand);
        if (role is null) return BadRequest();
        var roleResource = RoleResourceFromEntityAssembler.ToResourceFromEntity(role);
        return CreatedAtAction(nameof(GetRoleById), new {roleId = roleResource.RoleId}, roleResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        var getAllRolesQuery = new GetAllRolesQuery();
        var roles = await roleQueryService.Handle(getAllRolesQuery);
        var roleResources = roles.Select(RoleResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(roleResources);
    }

    [HttpGet("{roleId:int}")]
    public async Task<IActionResult> GetRoleById(int roleId)
    {
        var getRoleByIdQuery = new GetRoleByIdQuery(roleId);
        var role = await roleQueryService.Handle(getRoleByIdQuery);
        if (role == null) return NotFound();
        var roleResource = RoleResourceFromEntityAssembler.ToResourceFromEntity(role);
        return Ok(roleResource);
    }

    [HttpPut("{roleId:int}")]
    public async Task<IActionResult> UpdateRole(int roleId, UpdateRoleResource resource)
    {
        var updateRoleCommand = UpdateRoleCommandFromResourceAssembler.ToCommandFromResource(resource);
        await roleCommandService.Handle(updateRoleCommand);
        return NoContent();
    }

    [HttpDelete("{roleId:int}")]
    public async Task<IActionResult> DeleteRole(int roleId)
    {
        var deleteRoleCommand = new DeleteRoleCommand(roleId);
        await roleCommandService.Handle(deleteRoleCommand);
        return NoContent();
    }
}