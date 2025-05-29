namespace rirais.Domain.User.ValueObjects;

public record NationalCode
{
    public NationalCode(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public override string ToString() => Value;
}