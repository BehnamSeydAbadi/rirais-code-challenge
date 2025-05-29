using rirais.Domain.User;
using rirais.Domain.User.Dto;

namespace rirais.Application.User.Register;

internal class RegisterApplicationService : IRegisterApplicationService
{
    private readonly IUserRepository _userRepository;

    public RegisterApplicationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> HandleAsync(UserDto dto)
    {
        var userEntity = UserEntity.Register(dto);

        _userRepository.Add(userEntity);

        await _userRepository.SaveChangesAsync();

        return userEntity.Id;
    }
}