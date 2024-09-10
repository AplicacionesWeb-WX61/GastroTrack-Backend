using System.Net.Mime;
using chefstock_platform.RestaurantManagement.Domain.Model.Commands;
using chefstock_platform.RestaurantManagement.Domain.Services;
using chefstock_platform.RestaurantManagement.Interfaces.REST.Resources;
using chefstock_platform.RestaurantManagement.Interfaces.REST.Transform;
using chefstock_platform.RestaurantManagement.Domain.Model.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace chefstock_platform.RestaurantManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class RestaurantController(
    IRestaurantCommandService restaurantCommandService,
    IRestaurantQueryService restaurantQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateRestaurant(CreateRestaurantResource resource)
    {
        var createRestaurantCommand = CreateRestaurantCommandFromResourceAssembler.ToCommandFromResource(resource);
        var restaurant = await restaurantCommandService.Handle(createRestaurantCommand);
        if (restaurant is null) return BadRequest();
        var restaurantResource = RestaurantResourceFromEntityAssembler.ToResourceFromEntity(restaurant);
        return CreatedAtAction(nameof(GetRestaurantById), new {restaurantId = restaurantResource.RestaurantId}, restaurantResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRestaurants()
    {
        var getAllRestaurantsQuery = new GetAllRestaurantsQuery();
        var restaurants = await restaurantQueryService.Handle(getAllRestaurantsQuery);
        var restaurantResources = restaurants.Select(RestaurantResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(restaurantResources);
    }

    [HttpGet("{restaurantId:int}")]
    public async Task<IActionResult> GetRestaurantById(int restaurantId)
    {
        var getRestaurantByIdQuery = new GetRestaurantByIdQuery(restaurantId);
        var restaurant = await restaurantQueryService.Handle(getRestaurantByIdQuery);
        if (restaurant == null) return NotFound();
        var restaurantResource = RestaurantResourceFromEntityAssembler.ToResourceFromEntity(restaurant);
        return Ok(restaurantResource);
    }

    [HttpPut("{restaurantId:int}")]
    public async Task<IActionResult> UpdateRestaurant(int restaurantId, UpdateRestaurantResource resource)
    {
        var updateRestaurantCommand = UpdateRestaurantCommandFromResourceAssembler.ToCommandFromResource(resource);
        await restaurantCommandService.Handle(updateRestaurantCommand);
        return NoContent();
    }

    [HttpDelete("{restaurantId:int}")]
    public async Task<IActionResult> DeleteRestaurant(int restaurantId)
    {
        var deleteRestaurantCommand = new DeleteRestaurantCommand(restaurantId);
        await restaurantCommandService.Handle(deleteRestaurantCommand);
        return NoContent();
    }
}