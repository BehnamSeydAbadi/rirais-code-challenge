using rirais.Domain.User.Exceptions;
using rirais.Domain.User.ValueObjects;

namespace rirais.Domain.User;

public class UserEntity
{
    private UserEntity()
    {
    }

    public static UserEntity Register(string firstName, string lastName, string nationalCode, DateOnly dateOfBirth)
    {
        return new UserEntity
        {
            Id = Guid.NewGuid(),
            FullName = new FullName(firstName, lastName),
            NationalCode = new NationalCode(nationalCode),
            DateOfBirth = new DateOfBirth(dateOfBirth),
            RegisteredAt = DateTime.Now
        };
    }

    public void UpdateUserDetails(string firstName, string lastName, string nationalCode, DateOnly dateOfBirth)
    {
        if (UnregisteredAt is not null) throw new UnregisteredUserException();

        FullName = new FullName(firstName, lastName);
        NationalCode = new NationalCode(nationalCode);
        DateOfBirth = new DateOfBirth(dateOfBirth);
    }

    public void Unregister()
    {
        if (UnregisteredAt is not null) throw new UnregisteredUserException();

        UnregisteredAt = DateTime.Now;
    }

    public Guid Id { get; private set; }
    public FullName FullName { get; private set; }
    public NationalCode NationalCode { get; private set; }
    public DateOfBirth DateOfBirth { get; private set; }
    public DateTime RegisteredAt { get; private set; }
    public DateTime? UnregisteredAt { get; private set; }
}