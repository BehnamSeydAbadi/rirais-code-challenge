using Mapster;
using rirais.Application.User.ViewModels;
using rirais.Domain.User;

namespace rirais.Application.User.GetUsers;

internal class GetUsersApplicationService : IGetUsersApplicationService
{
    private readonly IUserRepository _userRepository;

    public GetUsersApplicationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserViewModel[]> HandleAsync()
    {
        return (await _userRepository.GetAsync()).Adapt<UserViewModel[]>();
    }
}