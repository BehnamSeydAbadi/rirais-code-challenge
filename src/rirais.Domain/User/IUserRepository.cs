using rirais.Domain.Common;

namespace rirais.Domain.User;

public interface IUserRepository
{
    void Add(UserEntity entity);
    Task<UserEntity?> GetAsync(Guid id, bool allowTracking = false);
    Task<UserEntity[]> GetAsync(bool allowTracking = false, params AbstractSpecification[] specifications);
    void Update(UserEntity entity);
    void Delete(UserEntity entity);
    Task<bool> AnyAsync(params AbstractSpecification[] specifications);
}