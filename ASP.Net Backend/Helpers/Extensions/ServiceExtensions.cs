using ASP.Net_Backend.Helpers.Seeders;

namespace ASP.Net_Backend.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddTransient<DataSeeder>();
            return services;
        }
    }
}
