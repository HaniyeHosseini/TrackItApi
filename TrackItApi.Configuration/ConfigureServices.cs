using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrackApi.Application.Features.Plans.Services;
using TrackApi.Infrastructure.Context;
using TrackApi.Infrastructure.JWT;
using TrackApi.Infrastructure.Repositories.Base;
using TrackApi.Infrastructure.Repositories.Base.Commands;
using TrackApi.Infrastructure.Repositories.Base.Queries;
using TrackApi.Infrastructure.Repositories.Goals;
using TrackApi.Infrastructure.Repositories.Goals.Commands;
using TrackApi.Infrastructure.Repositories.Goals.Queries;
using TrackApi.Infrastructure.Repositories.Jobs;
using TrackApi.Infrastructure.Repositories.Jobs.Commands;
using TrackApi.Infrastructure.Repositories.Jobs.Queries;
using TrackApi.Infrastructure.Repositories.Plans;
using TrackApi.Infrastructure.Repositories.Plans.Commands;
using TrackApi.Infrastructure.Repositories.Plans.Queries;
using TrackApi.Infrastructure.Repositories.Users;
using TrackApi.Infrastructure.Repositories.Users.Commands;
using TrackApi.Infrastructure.Repositories.Users.Queries;
using TrackItApi.Domain.Models;
namespace TrackItApi.Config
{
    public static class ConfigureServices
    {
        public static void Config(IServiceCollection services , string connectionString)
        {
            services.AddDbContext<TrackApiContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IBaseCommandRepository<BaseModel>, BaseCommandRepository<BaseModel>>();
            services.AddScoped<IBaseQueryRepository<BaseModel>, BaseQueryRepository<BaseModel>>();
            services.AddScoped<IPlanCommandRepository, PlanCommandRepository>();
            services.AddScoped<IPlanQueryRepository, PlanQueryRepository>();
            services.AddScoped<IPlanValidationService, PlanValidationService>();

            services.AddScoped<IGoalCommandRepository, GoalCommandRepository>();
            services.AddScoped<IGoalQueryRepository, GoalQueryRepository>();

            services.AddScoped<IJobCommandRepository, JobCommandRepository>();
            services.AddScoped<IJobQueryRepository, JobQueryRepository>();

            services.AddScoped<IUserCommandRepository, UserCommandRepository>();
            services.AddScoped<IUserQueryRepository, UserQueryRepository>();


            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
          

        }
    }
}
