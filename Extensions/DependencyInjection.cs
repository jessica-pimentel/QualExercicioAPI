using QualExercicioAPI.Services.Implementations;
using QualExercicioAPI.Services.Interfaces;
using QualExercicioAPI.Settings;

namespace QualExercicioAPI.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            // Serviços da aplicação
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtService, JwtService>();

            return services;
        }
    }
}
