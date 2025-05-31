namespace rirais.WebApi.ProtoServices;

internal class GrpcServices
{
    public static void Map(WebApplication app)
    {
        app.MapGrpcService<UserService>();

        app.MapGrpcReflectionService();
    }
}