using rirais.Application;
using rirais.Infrastructure;
using rirais.WebApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ApplicationBootstrapper.Run(builder.Services);
InfrastructureBootstrapper.Run(builder.Services, builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

UserEndpoints.Map(app);

app.UseSwagger();
app.UseSwaggerUI();


app.Run();