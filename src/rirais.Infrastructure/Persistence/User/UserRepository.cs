using Microsoft.EntityFrameworkCore;
using rirais.Domain.User;

namespace rirais.Infrastructure.Persistence.User;

public class UserRepository : IUserRepository
{
    private readonly RiRaDbContext _dbContext;

    public UserRepository(RiRaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(UserEntity entity) => _dbContext.Set<UserEntity>().Add(entity);

    public async Task<UserEntity?> GetAsync(Guid id, bool allowTracking = false)
    {
        return allowTracking
            ? await _dbContext.Set<UserEntity>().FirstOrDefaultAsync(u => u.Id == id)
            : await _dbContext.Set<UserEntity>().AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<UserEntity[]> GetAsync(bool allowTracking = false)
    {
        return allowTracking
            ? await _dbContext.Set<UserEntity>().ToArrayAsync()
            : await _dbContext.Set<UserEntity>().AsNoTracking().ToArrayAsync();
    }

    public void Update(UserEntity entity) => _dbContext.Set<UserEntity>().Update(entity);

    public void Delete(UserEntity entity) => _dbContext.Set<UserEntity>().Remove(entity);

    public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}