using Mapster;
using Microsoft.Extensions.DependencyInjection;
using rirais.Application.User.GetUser;
using rirais.Application.User.GetUsers;
using rirais.Application.User.Register;
using rirais.Application.User.UpdateUserDetails;
using rirais.Application.User.ViewModels;
using rirais.Domain.User;

namespace rirais.Application;

public class ApplicationBootstrapper
{
    public static void Run(IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IRegisterApplicationService, RegisterApplicationService>();
        serviceCollection.AddTransient<IUpdateUserDetailsApplicationService, UpdateUserDetailsApplicationService>();

        serviceCollection.AddTransient<IGetUserApplicationService, GetUserApplicationService>();
        serviceCollection.AddTransient<IGetUsersApplicationService, GetUsersApplicationService>();

        RegisterMappings();
    }

    private static void RegisterMappings()
    {
        TypeAdapterConfig<UserEntity, UserViewModel>.NewConfig()
            .Map(dest => dest.FirstName, src => src.FullName.FirstName)
            .Map(dest => dest.LastName, src => src.FullName.LastName)
            .Map(dest => dest.NationalCode, src => src.NationalCode.Value)
            .Map(dest => dest.DateOfBirth, src => src.DateOfBirth.ToString());
    }
}