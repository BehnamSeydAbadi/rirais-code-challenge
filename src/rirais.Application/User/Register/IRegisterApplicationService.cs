using rirais.Application.User.Dto;

namespace rirais.Application.User.Register;

public interface IRegisterApplicationService
{
    Task<Guid> HandleAsync(UserDto dto);
}