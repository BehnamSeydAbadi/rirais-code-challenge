using rirais.Domain.User.Exceptions;

namespace rirais.Domain.User.ValueObjects;

public record DateOfBirth
{
    public DateOfBirth(DateOnly value)
    {
        var ageInYears = DateOnly.FromDateTime(DateTime.Now).Year - value.Year;

        if (ageInYears <= 0 || 150 < ageInYears)
            throw new InvalidDateOfBirthException();

        Value = value;
    }

    public DateOnly Value { get; private set; }

    public override string ToString() => Value.ToString("yyyy-MM-dd");
}