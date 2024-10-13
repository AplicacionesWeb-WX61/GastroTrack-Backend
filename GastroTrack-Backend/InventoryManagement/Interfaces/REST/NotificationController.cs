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
public class NotificationController : ControllerBase
{
    private readonly INotificationCommandService _notificationCommandService;
    private readonly INotificationQueryService _notificationQueryService;

    public NotificationController(INotificationCommandService notificationCommandService, INotificationQueryService notificationQueryService)
    {
        _notificationCommandService = notificationCommandService;
        _notificationQueryService = notificationQueryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNotification(CreateNotificationResource resource)
    {
        var createNotificationCommand = CreateNotificationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var notification = await _notificationCommandService.Handle(createNotificationCommand);
        if (notification is null) return BadRequest();
        var notificationResource = NotificationResourceFromEntityAssembler.ToResourceFromEntity(notification);
        
        // Corregido: notificationId en vez de notificationtId
        return CreatedAtAction(nameof(GetNotificationById), new { notificationId = notificationResource.NotificationId }, notificationResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllNotification()
    {
        var getAllNotificationQuery = new GetAllNotificationQuery();
        var notifications = await _notificationQueryService.Handle(getAllNotificationQuery);
        var notificationResources = notifications.Select(NotificationResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(notificationResources);
    }

    [HttpGet("{notificationId:int}")]
    public async Task<IActionResult> GetNotificationById(int notificationId)
    {
        var getNotificationByIdQuery = new GetNotificationByIdQuery(notificationId);
        var notification = await _notificationQueryService.Handle(getNotificationByIdQuery);
        if (notification == null) return NotFound();
        var notificationResource = NotificationResourceFromEntityAssembler.ToResourceFromEntity(notification);
        return Ok(notificationResource);
    }

    [HttpPut("{notificationId:int}")]
    public async Task<IActionResult> UpdateNotification(int notificationId, UpdateNotificationResource resource)
    {
        var updateNotificationCommand = UpdateNotificationCommandFromResourceAssembler.ToCommandFromResource(resource);
        await _notificationCommandService.Handle(updateNotificationCommand);
        return NoContent();
    }

    [HttpDelete("{notificationId:int}")]
    public async Task<IActionResult> DeleteNotification(int notificationId)
    {
        var deleteNotificationCommand = new DeleteNotificationCommand(notificationId);
        await _notificationCommandService.Handle(deleteNotificationCommand);
        return NoContent();
    }
}