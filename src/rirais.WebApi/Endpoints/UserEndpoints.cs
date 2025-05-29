using Microsoft.AspNetCore.Mvc;
using rirais.Application.User.GetUser;
using rirais.Application.User.GetUsers;
using rirais.Application.User.Register;
using rirais.Domain.User.Dto;

namespace rirais.WebApi.Endpoints;

public class UserEndpoints
{
    public static void Map(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("api/users",
            async ([FromServices] IRegisterApplicationService registerApplicationService, [FromBody] UserDto userDto) =>
            {
                var userId = await registerApplicationService.HandleAsync(userDto);
                return Results.Created(uri: $"/api/users/{userId}", userId);
            });

        endpoints.MapGet("api/users/{id:guid}",
            async ([FromServices] IGetUserApplicationService getUserApplicationService, [FromRoute] Guid id) =>
            {
                var userViewModel = await getUserApplicationService.HandleAsync(id);
                return userViewModel is null ? Results.NoContent() : Results.Ok(userViewModel);
            });

        endpoints.MapGet("api/users",
            async ([FromServices] IGetUsersApplicationService getUsersApplicationService) =>
            {
                var userViewModels = await getUsersApplicationService.HandleAsync();
                return Results.Ok(userViewModels);
            });
    }
}