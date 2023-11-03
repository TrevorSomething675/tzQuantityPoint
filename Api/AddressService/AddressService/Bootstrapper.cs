using AddressService.Services;
using AddressService.Services.Abstractions;

namespace AddressService
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpClient();
            services.AddScoped<IClientService, ClientService>();

            return services;
        }
    }
}
