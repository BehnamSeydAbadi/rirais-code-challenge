using rirais.Domain.Common;

namespace rirais.Domain.User.Specifications;

public class UserByNationalCodeSpecification(string nationalCode) : AbstractSpecification
{
    public string NationalCode { get; } = nationalCode;
}