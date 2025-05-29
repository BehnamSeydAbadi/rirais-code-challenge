using rirais.Domain.User.Dto;

namespace rirais.Application.User.Register;

public interface IRegisterApplicationService
{
    Task<Guid> HandleAsync(UserDto dto);
}