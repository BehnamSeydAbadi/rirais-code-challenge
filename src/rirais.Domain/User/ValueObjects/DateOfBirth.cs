namespace rirais.Domain.User.ValueObjects;

public record DateOfBirth
{
    public DateOfBirth(DateOnly value)
    {
        Value = value;
    }

    public DateOnly Value { get; private set; }

    public override string ToString() => Value.ToString("yyyy-MM-dd");
}