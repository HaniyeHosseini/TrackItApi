using TrackApi.Application.Mappings;
using TrackItApi.Common;
using TrackItApi.Config;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;
using TrackApi.Application.Validators;
using Host.Middlewares;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new PersianDateJsonConverter());
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<InputCreationPlanValidator>();

ConfigureServices.Config(builder.Services, builder.Configuration.GetConnectionString("TrackItApiConnection"));
var app = builder.Build();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
ServiceLocator.SetServiceProvider(app.Services);
MappingConfig.RegisterMappings();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
