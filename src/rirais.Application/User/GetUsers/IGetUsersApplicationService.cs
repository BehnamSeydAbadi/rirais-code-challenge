using rirais.Application.User.ViewModels;

namespace rirais.Application.User.GetUsers;

public interface IGetUsersApplicationService
{
    Task<UserViewModel[]> HandleAsync();
}