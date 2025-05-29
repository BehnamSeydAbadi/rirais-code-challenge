namespace rirais.Domain.User.ValueObjects;

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