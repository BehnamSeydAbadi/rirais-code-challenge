using rirais.Application.User.Dto;

namespace rirais.Application.User.UpdateUserDetails;

public interface IUpdateUserDetailsApplicationService
{
    Task HandleAsync(Guid id, UserDto dto);
}