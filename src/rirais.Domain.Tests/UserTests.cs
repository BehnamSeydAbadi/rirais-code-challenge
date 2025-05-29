using rirais.Domain.User;
using rirais.Domain.User.Dto;

namespace rirais.Domain.Tests;

public class UserTests
{
    [Fact(DisplayName = "When a user gets registered, Then the user should be registered successfully")]
    public void RegisterUserSuccessfully()
    {
        var dto = new UserDto
        {
            FirstName = "John",
            LastName = "Doe",
            NationalCode = "0",
            DateOfBirth = new DateOnly(1997, 3, 27)
        };

        var user = UserEntity.Register(dto);

        user.FullName.FirstName.Should().Be(dto.FirstName);
        user.FullName.LastName.Should().Be(dto.LastName);
        user.NationalCode.Value.Should().Be(dto.NationalCode);
        user.DateOfBirth.Value.Should().Be(dto.DateOfBirth);
    }
}