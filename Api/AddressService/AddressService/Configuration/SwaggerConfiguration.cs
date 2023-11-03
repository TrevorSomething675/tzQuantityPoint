using AddressService.Settings.SettingsModels;
using Microsoft.Extensions.Options;

namespace AddressService.Configuration
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddAppSwagger(this IServiceCollection services, SwaggerSettings settings)
        {
            if (!settings?.Enabled ?? false)
                return services;

            services.AddSwaggerGen();

            return services;
        }

        public static void UseAppSwagger(this WebApplication app, SwaggerSettings settings)
        {
            if (!settings?.Enabled ?? false)
                return;
            app.UseSwagger();

            app.UseSwaggerUI(options =>
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "AddressService")
            );
        }
    }
}
