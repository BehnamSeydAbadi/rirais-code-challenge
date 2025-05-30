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
            DateOfBirth = new DateOfBirth(dateOfBirth)
        };
    }

    public void UpdateUserDetails(string firstName, string lastName, string nationalCode, DateOnly dateOfBirth)
    {
        FullName = new FullName(firstName, lastName);
        NationalCode = new NationalCode(nationalCode);
        DateOfBirth = new DateOfBirth(dateOfBirth);
    }

    public Guid Id { get; private set; }
    public FullName FullName { get; private set; }
    public NationalCode NationalCode { get; private set; }
    public DateOfBirth DateOfBirth { get; private set; }
}