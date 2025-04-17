using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrackApi.Application.Services.Goals;
using TrackApi.Application.Services.Jobs;
using TrackApi.Application.Services.Plans;
using TrackApi.Infrastructure.Context;
using TrackApi.Infrastructure.Repositories.Base;
using TrackApi.Infrastructure.Repositories.Goals;
using TrackApi.Infrastructure.Repositories.Jobs;
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
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IJobRepository, JobRepository>();
        }
    }
}
