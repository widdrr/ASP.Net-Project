using ASP.Net_Backend.Data;
using ASP.Net_Backend.Helpers.Authorization;
using ASP.Net_Backend.Helpers.Seeders;
using ASP.Net_Backend.Repositories;
using ASP.Net_Backend.Services;

namespace ASP.Net_Backend.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddTransient<DataSeeder>();
            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
        public static IServiceCollection AddUtility(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtility, JwtUtility>();

            return services;
        }
    }
}
