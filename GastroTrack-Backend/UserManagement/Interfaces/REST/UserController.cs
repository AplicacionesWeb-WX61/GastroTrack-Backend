using System.Net.Mime;
using chefstock_platform.UserManagement.Domain.Model.Commands;
using chefstock_platform.UserManagement.Domain.Services;
using chefstock_platform.UserManagement.Interfaces.REST.Resources;
using chefstock_platform.UserManagement.Interfaces.REST.Transform;
using chefstock_platform.UserManagement.Domain.Model.Queries;
using Microsoft.AspNetCore.Mvc;

namespace chefstock_platform.UserManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UserController(IUserCommandService userCommandService, IUserQueryService userQueryService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserResource resource)
    {
        var createUserCommand = CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        var user = await userCommandService.Handle(createUserCommand);
        if (user is null) return BadRequest();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return CreatedAtAction(nameof(GetUserById), new {userId = userResource.UserId}, userResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var getAllUsersQuery = new GetAllUsersQuery();
        var users = await userQueryService.Handle(getAllUsersQuery);
        var userResources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(userResources);
    }

    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var user = await userQueryService.Handle(getUserByIdQuery);
        if (user == null) return NotFound();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }

    [HttpPut("{userId:int}")]
    public async Task<IActionResult> UpdateUser(int userId, UpdateUserResource resource)
    {
        var updateUserCommand = UpdateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        await userCommandService.Handle(updateUserCommand);
        return NoContent();
    }

    [HttpDelete("{userId:int}")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        var deleteUserCommand = new DeleteUserCommand(userId);
        await userCommandService.Handle(deleteUserCommand);
        return NoContent();
    }
}