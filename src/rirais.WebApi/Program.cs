using rirais.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ApplicationBootstrapper.Run(builder.Services);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.Run();