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

        var user = User.Register(dto);

        user.FullName.FirstName.Should().Be(dto.FirstName);
        user.FullName.LastName.Should().Be(dto.LastName);
        user.NationalCode.Value.Should().Be(dto.NationalCode);
        user.DateOfBirth.Value.Should().Be(dto.DateOfBirth);
    }
}

public class User
{
    private User()
    {
    }

    public static User Register(UserDto dto)
    {
        return new User
        {
            FullName = new FullName(dto.FirstName, dto.LastName),
            NationalCode = new NationalCode(dto.NationalCode),
            DateOfBirth = new DateOfBirth(dto.DateOfBirth)
        };
    }

    public FullName FullName { get; private set; }
    public NationalCode NationalCode { get; private set; }
    public DateOfBirth DateOfBirth { get; private set; }
}

public record FullName
{
    public FullName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Value => $"{FirstName} {LastName}";
}

public record NationalCode
{
    public NationalCode(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public override string ToString() => Value;
}

public record DateOfBirth
{
    public DateOfBirth(DateOnly value)
    {
        Value = value;
    }

    public DateOnly Value { get; private set; }

    public override string ToString() => Value.ToString("yyyy-MM-dd");
}

public record UserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public DateOnly DateOfBirth { get; set; }
}