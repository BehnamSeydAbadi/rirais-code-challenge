using rirais.Application.UnitOfWork;
using rirais.Application.User.Exceptions;

namespace rirais.Application.User.Unregister;

internal class UnregisterUserApplicationService(IUnitOfWork unitOfWork) : IUnregisterUserApplicationService
{
    public async Task HandleAsync(Guid id)
    {
        var user = await unitOfWork.UserRepository.GetAsync(id);

        if (user is null) throw new UserNotFoundException();

        user.Unregister();

        unitOfWork.UserRepository.Delete(user);

        await unitOfWork.SaveChangesAsync();
    }
}