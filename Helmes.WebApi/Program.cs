using Helmes.Shared.Repository;
var MyAllowSpecificOrigins = "_myAllowOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DatabaseContext>(ServiceLifetime.Singleton);
builder.Services.AddEndpointDefinitions(typeof(IEndpointDefinition));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder
                          .AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                      });
});

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
app.UseEndpointDefinitions();
app.Run();
