
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace TrackItApi.Common
{
    public static class ServiceLocator
    {
        private static  IServiceProvider? _serviceProvider;
        public static void SetServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public static T GetService<T>() where T : notnull
        {
            if (_serviceProvider == null)
                throw new InvalidOperationException("ServiceProvider هنوز مقداردهی نشده است!");
            using var scope = _serviceProvider.CreateScope();
            return scope.ServiceProvider.GetRequiredService<T>();
        }
    }
}
