using rirais.Domain.User.Dto;
using rirais.Domain.User.ValueObjects;

namespace rirais.Domain.User;

public class UserEntity
{
    private UserEntity()
    {
    }

    public static UserEntity Register(UserDto dto)
    {
        return new UserEntity
        {
            Id = Guid.NewGuid(),
            FullName = new FullName(dto.FirstName, dto.LastName),
            NationalCode = new NationalCode(dto.NationalCode),
            DateOfBirth = new DateOfBirth(dto.DateOfBirth)
        };
    }

    public Guid Id { get; private set; }
    public FullName FullName { get; private set; }
    public NationalCode NationalCode { get; private set; }
    public DateOfBirth DateOfBirth { get; private set; }
}