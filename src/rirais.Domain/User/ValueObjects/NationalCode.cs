using rirais.Domain.User.Exceptions;

namespace rirais.Domain.User.ValueObjects;

public record NationalCode
{
    public NationalCode(string value)
    {
        if (string.IsNullOrWhiteSpace(value)
            || value.Length != 10
            || value.ToCharArray().Any(c => char.IsDigit(c) is false))
            throw new InvalidNationalCodeException();

        Value = value;
    }

    public string Value { get; private set; }

    public override string ToString() => Value;
}