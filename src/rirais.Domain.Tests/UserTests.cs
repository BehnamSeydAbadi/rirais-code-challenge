using rirais.Domain.Tests.Dto;
using rirais.Domain.User;
using rirais.Domain.User.Exceptions;

namespace rirais.Domain.Tests;

public class UserTests
{
    [Fact(DisplayName = "When a user gets registered, Then the user should be registered successfully")]
    public void RegisterUserSuccessfully()
    {
        var dto = new UserInfromationDto
        {
            FirstName = "John",
            LastName = "Doe",
            NationalCode = "0019946163",
            DateOfBirth = new DateOnly(1997, 3, 27)
        };

        var user = UserEntity.Register(dto.FirstName, dto.LastName, dto.NationalCode, dto.DateOfBirth);

        user.Id.Should().NotBe(Guid.Empty);
        user.FullName.FirstName.Should().Be(dto.FirstName);
        user.FullName.LastName.Should().Be(dto.LastName);
        user.NationalCode.Value.Should().Be(dto.NationalCode);
        user.DateOfBirth.Value.Should().Be(dto.DateOfBirth);
    }

    [Fact(DisplayName = "When a user gets registered with invalid national code, Then an exception should be thrown")]
    public void RegisterUserWithInvalidNationalCodeShouldThrowAnException()
    {
        var dto = new UserInfromationDto
        {
            FirstName = "John",
            LastName = "Doe",
            NationalCode = "0",
            DateOfBirth = new DateOnly(1997, 3, 27)
        };

        var action = () => UserEntity.Register(dto.FirstName, dto.LastName, dto.NationalCode, dto.DateOfBirth);

        action.Should().ThrowExactly<InvalidNationalCodeException>();
    }

    [Fact(DisplayName =
        "When a user gets registered with invalid first name, Then an exception should be thrown")]
    public void RegisterUserWithInvalidFirstNameShouldThrowAnException()
    {
        var dto = new UserInfromationDto
        {
            FirstName = string.Empty,
            LastName = "Doe",
            NationalCode = "0019946163",
            DateOfBirth = new DateOnly(1997, 3, 27)
        };

        var registerWithInvalidFirstNameAction =
            () => UserEntity.Register(dto.FirstName, dto.LastName, dto.NationalCode, dto.DateOfBirth);
        registerWithInvalidFirstNameAction.Should().ThrowExactly<InvalidFullNameException>();

        dto.FirstName = "John";
        dto.LastName = string.Empty;
        var registerWithInvalidLastNameAction =
            () => UserEntity.Register(dto.FirstName, dto.LastName, dto.NationalCode, dto.DateOfBirth);
        registerWithInvalidLastNameAction.Should().ThrowExactly<InvalidFullNameException>();
    }

    [Fact(DisplayName =
        "When a user gets registered with invalid date of birth, Then an exception should be thrown")]
    public void RegisterUserWithInvalidDateOfBirthShouldThrowAnException()
    {
        var dto = new UserInfromationDto
        {
            FirstName = "John",
            LastName = "Doe",
            NationalCode = "0019946163",
            DateOfBirth = DateOnly.MinValue
        };

        var registerWithMinDateOfBirthAction =
            () => UserEntity.Register(dto.FirstName, dto.LastName, dto.NationalCode, dto.DateOfBirth);
        registerWithMinDateOfBirthAction.Should().ThrowExactly<InvalidDateOfBirthException>();

        dto.DateOfBirth = DateOnly.MaxValue;
        var registerWithMaxDateOfBirthAction =
            () => UserEntity.Register(dto.FirstName, dto.LastName, dto.NationalCode, dto.DateOfBirth);
        registerWithMaxDateOfBirthAction.Should().ThrowExactly<InvalidDateOfBirthException>();
    }


    [Fact(DisplayName =
        "There is a user already registered, When his information gets updated, Then his information should be updated successfully")]
    public void UpdateUserInformationSuccessfully()
    {
        var user = UserEntity.Register(
            firstName: "x", lastName: "y", nationalCode: "0023359865", dateOfBirth: new DateOnly(1900, 1, 1)
        );

        var dto = new UserInfromationDto
        {
            FirstName = "John",
            LastName = "Doe",
            NationalCode = "0019946163",
            DateOfBirth = new DateOnly(1997, 3, 27)
        };

        user.UpdateUserDetails(dto.FirstName, dto.LastName, dto.NationalCode, dto.DateOfBirth);

        user.FullName.FirstName.Should().Be(dto.FirstName);
        user.FullName.LastName.Should().Be(dto.LastName);
        user.NationalCode.Value.Should().Be(dto.NationalCode);
        user.DateOfBirth.Value.Should().Be(dto.DateOfBirth);
    }
}