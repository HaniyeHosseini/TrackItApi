using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrackApi.Infrastructure.Context;
namespace TrackItApi.Config
{
    public static class ConfigureServices
    {
        public static void Config(IServiceCollection services , string connectionString)
        {
            services.AddDbContext<TrackApiContext>(options => options.UseSqlServer(connectionString));
        }

    }
}
