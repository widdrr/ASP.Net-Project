using Backend.Data;
using Backend.Helpers.Authorization;
using Backend.Helpers.Seeders;
using Backend.Repositories.GameRepository;
using Backend.Repositories.TransactionRepository;
using Backend.Repositories.UserRepository;
using Backend.Services.GameService;
using Backend.Services.TransactionService;
using Backend.Services.UserService;

namespace Backend.Helpers.Extensions
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
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITransactionService, TransactionService>();

            return services;
        }
        public static IServiceCollection AddUtility(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtility, JwtUtility>();

            return services;
        }
    }
}
