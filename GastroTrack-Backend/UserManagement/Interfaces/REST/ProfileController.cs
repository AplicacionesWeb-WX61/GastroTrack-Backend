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
public class ProfileController(IProfileCommandService profileCommandService, IProfileQueryService profileQueryService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProfile(CreateProfileResource resource)
    {
        var createProfileCommand = CreateProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
        var profile = await profileCommandService.Handle(createProfileCommand);
        if (profile is null) return BadRequest();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return CreatedAtAction(nameof(GetProfileById), new {profileId = profileResource.ProfileId}, profileResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProfiles()
    {
        var getAllProfilesQuery = new GetAllProfilesQuery();
        var profiles = await profileQueryService.Handle(getAllProfilesQuery);
        var profileResources = profiles.Select(ProfileResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(profileResources);
    }

    [HttpGet("{profileId:int}")]
    public async Task<IActionResult> GetProfileById(int profileId)
    {
        var getProfileByIdQuery = new GetProfileByIdQuery(profileId);
        var profile = await profileQueryService.Handle(getProfileByIdQuery);
        if (profile == null) return NotFound();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return Ok(profileResource);
    }

    [HttpPut("{profileId:int}")]
    public async Task<IActionResult> UpdateProfile(int profileId, UpdateProfileResource resource)
    {
        var updateProfileCommand = UpdateProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
        await profileCommandService.Handle(updateProfileCommand);
        return NoContent();
    }

    [HttpDelete("{profileId:int}")]
    public async Task<IActionResult> DeleteProfile(int profileId)
    {
        var deleteProfileCommand = new DeleteProfileCommand(profileId);
        await profileCommandService.Handle(deleteProfileCommand);
        return NoContent();
    }
}