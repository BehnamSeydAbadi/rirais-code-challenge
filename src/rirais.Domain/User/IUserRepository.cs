namespace rirais.Domain.User;

public interface IUserRepository
{
    void Add(UserEntity entity);
    Task<UserEntity?> GetAsync(Guid id, bool allowTracking = false);
    Task<UserEntity[]> GetAsync(bool allowTracking = false);
    void Update(UserEntity entity);
    void Delete(UserEntity entity);
    Task SaveChangesAsync();
}