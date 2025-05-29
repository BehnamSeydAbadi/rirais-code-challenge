using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using rirais.Domain.User;
using rirais.Infrastructure.Persistence;
using rirais.Infrastructure.Persistence.User;

namespace rirais.Infrastructure;

public class InfrastructureBootstrapper
{
    public static void Run(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RiRaDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default"))
        );

        services.AddScoped<IUserRepository, UserRepository>();
    }
}