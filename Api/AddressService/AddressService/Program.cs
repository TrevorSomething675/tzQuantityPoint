using AddressService.Settings.SettingsModels;
using AddressService.Configuration;
using AddressService.Settings;
using AddressService;

var builder = WebApplication.CreateBuilder(args);

var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");
var mainSettings = Settings.Load<MainSettings>("Main");

builder.AddAppLogger();

var services = builder.Services;

services.RegisterAppServices();
services.AddAppSwagger(swaggerSettings);

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.UseAppSwagger(swaggerSettings);

app.Run();
