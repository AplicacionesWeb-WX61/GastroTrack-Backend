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
public class TaskController(ITaskCommandService taskCommandService, ITaskQueryService taskQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTask(CreateTaskResource resource)
    {
        var createTaskCommand = CreateTaskCommandFromResourceAssembler.ToCommandFromResource(resource);
        var tasks = await taskCommandService.Handle(createTaskCommand);
        if (tasks is null) return BadRequest();
        var taskResource = TaskResourceFromEntityAssembler.ToResourceFromEntity(tasks);
        return CreatedAtAction(nameof(GetTaskById), new {taskId = taskResource.TaskId}, taskResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        var getAllTaskQuery = new GetAllTasksQuery();
        var tasks = await taskQueryService.Handle(getAllTaskQuery);
        var taskResources = tasks.Select(TaskResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(taskResources);
    }

    [HttpGet("{taskId:int}")]
    public async Task<IActionResult> GetTaskById(int taskId)
    {
        var getTaskByIdQuery = new GetTasksByIdQuery(taskId);
        var tasks = await taskQueryService.Handle(getTaskByIdQuery);
        if (tasks == null) return NotFound();
        var taskResource = TaskResourceFromEntityAssembler.ToResourceFromEntity(tasks);
        return Ok(taskResource);
    }

    [HttpPut("{taskId:int}")]
    public async Task<IActionResult> UpdateTask(int id, UpdateTaskResource resource)
    {
        var updateTaskCommand = UpdateTaskCommandFromResourceAssembler.ToCommandFromResource(resource);
        await taskCommandService.Handle(updateTaskCommand);
        return NoContent();
    }

    [HttpDelete("{taskId:int}")]
    public async Task<IActionResult> DeleteProduct(int taskId)
    {
        var deleteTaskCommand = new DeleteTaskCommand(taskId);
        await taskCommandService.Handle(deleteTaskCommand);
        return NoContent();
    }
}