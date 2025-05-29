using Microsoft.Extensions.DependencyInjection;
using rirais.Application.User;
using rirais.Application.User.Register;

namespace rirais.Application;

public class ApplicationBootstrapper
{
    public static void Run(IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IRegisterApplicationService, RegisterApplicationService>();
    }
}