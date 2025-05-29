using rirais.Application.User.ViewModels;

namespace rirais.Application.User.GetUser;

public interface IGetUserApplicationService
{
    Task<UserViewModel?> HandleAsync(Guid id);
}