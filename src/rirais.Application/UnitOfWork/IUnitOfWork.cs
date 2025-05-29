using rirais.Domain.User;

namespace rirais.Application.UnitOfWork;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }

    Task SaveChangesAsync();
}