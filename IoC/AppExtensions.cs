namespace IoC
{
    using Domain.Interfaces.Services;
    using Microsoft.Extensions.DependencyInjection;
    using Services.Implementations;

    public static class AppAddServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPowerPlantService, PowerPlantService>();
            return services;
        }
    }
}