using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrackApi.Application.Goals.Contracts;
using TrackApi.Application.Goals.Implements;
using TrackApi.Application.Plans.Contracts;
using TrackApi.Application.Plans.Implements;
using TrackApi.Infrastructure.Context;
using TrackApi.Infrastructure.Repositories.Base;
using TrackApi.Infrastructure.Repositories.Goals;
using TrackApi.Infrastructure.Repositories.Plans;
using TrackItApi.Domain.Models;
namespace TrackItApi.Config
{
    public static class ConfigureServices
    {
        public static void Config(IServiceCollection services , string connectionString)
        {
            services.AddDbContext<TrackApiContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IBaseRepository<BaseModel>, BaseRepository<BaseModel>>();
            services.AddScoped<IPlanRepository, PlanRepository>();
            services.AddScoped<IPlanService, PlanService>();
            services.AddScoped<IGoalRepository, GoalRepository>();
            services.AddScoped<IGoalService, GoalService>();
            services.AddScoped<IGoalValidationService, GoalValidationService>();
            services.AddScoped<IPlanValidationService, PlanValidationService>();



        }
    }
}
