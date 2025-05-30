namespace rirais.Application.User.Unregister;

public interface IUnregisterUserApplicationService
{
    Task HandleAsync(Guid id);
}