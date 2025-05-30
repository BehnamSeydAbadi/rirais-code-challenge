using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rirais.Domain.User;
using rirais.Domain.User.ValueObjects;

namespace rirais.Infrastructure.Persistence.User;

public class UserEfConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable(name: "Users");
        builder.HasKey(u => u.Id);
        builder.OwnsOne(u => u.FullName, onb =>
        {
            onb.Property(fn => fn.FirstName).HasMaxLength(FullName.FirstNameMaxLength).IsRequired();
            onb.Property(fn => fn.LastName).HasMaxLength(FullName.LastNameMaxLength).IsRequired();
        });
        builder.OwnsOne(u => u.NationalCode, onb =>
        {
            onb.Property(nc => nc.Value).HasMaxLength(10).IsRequired();
            onb.HasIndex(nc => nc.Value).IsUnique();
        });
        builder.OwnsOne(u => u.DateOfBirth, onb => onb.Property(dob => dob.Value).IsRequired());
    }
}