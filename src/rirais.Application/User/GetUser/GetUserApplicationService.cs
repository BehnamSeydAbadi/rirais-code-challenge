using Mapster;
using rirais.Application.User.ViewModels;
using rirais.Domain.User;

namespace rirais.Application.User.GetUser;

internal class GetUserApplicationService : IGetUserApplicationService
{
    private readonly IUserRepository _userRepository;

    public GetUserApplicationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserViewModel?> HandleAsync(Guid id)
    {
        return (await _userRepository.GetAsync(id))?.Adapt<UserViewModel>();
    }
}