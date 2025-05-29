using Microsoft.EntityFrameworkCore;
using rirais.Infrastructure.Persistence.User;

namespace rirais.Infrastructure.Persistence;

public class RiRaDbContext : DbContext
{
    public RiRaDbContext(DbContextOptions<RiRaDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEfConfiguration).Assembly);
    }
}