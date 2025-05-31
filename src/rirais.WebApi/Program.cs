using rirais.Application;
using rirais.Infrastructure;
using rirais.WebApi.Endpoints;
using rirais.WebApi.ProtoServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

ApplicationBootstrapper.Run(builder.Services);
InfrastructureBootstrapper.Run(builder.Services, builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (builder.Configuration.GetValue<bool>("UseGrpc"))
{
    GrpcServices.Map(app);
}
else
{
    UserEndpoints.Map(app);
}

app.UseSwagger();
app.UseSwaggerUI();

app.Run();