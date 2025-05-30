using rirais.Domain.User.Exceptions;

namespace rirais.Domain.User.ValueObjects;

public record FullName
{
    public const int FirstNameMaxLength = 64;
    public const int LastNameMaxLength = 64;

    public FullName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName)
            || string.IsNullOrWhiteSpace(lastName)
            || firstName.Length > FirstNameMaxLength
            || lastName.Length > LastNameMaxLength)
            throw new InvalidFullNameException();

        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Value => $"{FirstName} {LastName}";
}