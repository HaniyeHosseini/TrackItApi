using TrackApi.Application.Plans.Mappings;
using TrackItApi.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ConfigureServices.Config(builder.Services, builder.Configuration.GetConnectionString("TrackItApiConnection"));
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

MappingConfig.RegisterMappings();

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();
