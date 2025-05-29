using rirais.Application.UnitOfWork;
using rirais.Domain.User;

namespace rirais.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly RiRaDbContext _dbContext;

    public UnitOfWork(
        RiRaDbContext dbContext, IUserRepository userRepository
    )
    {
        _dbContext = dbContext;
        UserRepository = userRepository;
    }

    public IUserRepository UserRepository { get; }

    public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}