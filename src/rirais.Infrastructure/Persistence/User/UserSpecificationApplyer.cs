using rirais.Domain.Common;
using rirais.Domain.User;
using rirais.Domain.User.Specifications;

namespace rirais.Infrastructure.Persistence.User;

internal class UserSpecificationApplyer
{
    public static IQueryable<UserEntity> Apply(
        IQueryable<UserEntity> query, params AbstractSpecification[] specifications)
    {
        foreach (var specification in specifications)
        {
            query = ApplySpecification(query, (dynamic)specification);
        }

        return query;
    }


    private static IQueryable<UserEntity> ApplySpecification(
        IQueryable<UserEntity> query, UserByNationalCodeSpecification specification
    ) => query.Where(u => u.NationalCode.Value == specification.NationalCode);
}