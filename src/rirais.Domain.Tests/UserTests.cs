using rirais.Domain.User;
using rirais.Domain.User.Dto;
using rirais.Domain.User.Exceptions;

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
            NationalCode = "0019946163",
            DateOfBirth = new DateOnly(1997, 3, 27)
        };

        var user = UserEntity.Register(dto);

        user.Id.Should().NotBe(Guid.Empty);
        user.FullName.FirstName.Should().Be(dto.FirstName);
        user.FullName.LastName.Should().Be(dto.LastName);
        user.NationalCode.Value.Should().Be(dto.NationalCode);
        user.DateOfBirth.Value.Should().Be(dto.DateOfBirth);
    }

    [Fact(DisplayName = "When a user gets registered with invalid national code, Then an exception should be thrown")]
    public void RegisterUserWithInvalidNationalCodeShouldThrowAnException()
    {
        var dto = new UserDto
        {
            FirstName = "John",
            LastName = "Doe",
            NationalCode = "0",
            DateOfBirth = new DateOnly(1997, 3, 27)
        };

        var action = () => UserEntity.Register(dto);

        action.Should().ThrowExactly<InvalidNationalCodeException>();
    }

    [Fact(DisplayName =
        "When a user gets registered with invalid first name, Then an exception should be thrown")]
    public void RegisterUserWithInvalidFirstNameShouldThrowAnException()
    {
        var dto = new UserDto
        {
            FirstName = "",
            LastName = "Doe",
            NationalCode = "0019946163",
            DateOfBirth = new DateOnly(1997, 3, 27)
        };

        var action = () => UserEntity.Register(dto);

        action.Should().ThrowExactly<InvalidFullNameException>();
    }

    [Fact(DisplayName =
        "When a user gets registered with invalid last name, Then an exception should be thrown")]
    public void RegisterUserWithInvalidLastNameShouldThrowAnException()
    {
        var dto = new UserDto
        {
            FirstName = "John",
            LastName = "",
            NationalCode = "0019946163",
            DateOfBirth = new DateOnly(1997, 3, 27)
        };

        var action = () => UserEntity.Register(dto);

        action.Should().ThrowExactly<InvalidFullNameException>();
    }
}