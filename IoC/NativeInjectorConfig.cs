using Data.Repositories;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IClientEFRepository, ClientEFRepository>();
        }
    }
}
