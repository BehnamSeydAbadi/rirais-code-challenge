using Microsoft.AspNetCore.Mvc;
using rirais.Application.User.Dto;
using rirais.Application.User.GetUser;
using rirais.Application.User.GetUsers;
using rirais.Application.User.Register;
using rirais.Application.User.UpdateUserDetails;

namespace rirais.WebApi.Endpoints;

public class UserEndpoints
{
    public static void Map(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("api/users",
            async ([FromServices] IRegisterApplicationService applicationService, [FromBody] UserDto userDto) =>
            {
                var userId = await applicationService.HandleAsync(userDto);
                return Results.Created(uri: $"/api/users/{userId}", userId);
            });

        endpoints.MapGet("api/users/{id:guid}",
            async ([FromServices] IGetUserApplicationService applicationService, [FromRoute] Guid id) =>
            {
                var userViewModel = await applicationService.HandleAsync(id);
                return userViewModel is null ? Results.NoContent() : Results.Ok(userViewModel);
            });

        endpoints.MapGet("api/users",
            async ([FromServices] IGetUsersApplicationService applicationService) =>
            {
                var userViewModels = await applicationService.HandleAsync();
                return Results.Ok(userViewModels);
            });

        endpoints.MapPut("api/users/{id:guid}", async (
            [FromServices] IUpdateUserDetailsApplicationService applicationService,
            [FromRoute] Guid id, [FromBody] UserDto userDto
        ) =>
        {
            await applicationService.HandleAsync(id, userDto);
            return Results.Ok();
        });
    }
}