using AddressService.Settings.SettingsModels;
using AddressService.Services.Abstractions;
using AddressService.Controllers;
using System.Text;

namespace AddressService.Services
{
    public class ClientService : IClientService
    {
        private readonly MainSettings _settings;
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public ClientService(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _settings = Settings.Settings.Load<MainSettings>("Main");
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<string> SendPostRequest(string message, MainSettings overrideSettings = null)
        {
            string result = "";
            using (var client = _httpClientFactory.CreateClient())
            {
                if(overrideSettings == null) { 
                    var content = new StringContent($"[\"{message}\" ]", Encoding.UTF8, $"{_settings.ContentType}");
                    client.DefaultRequestHeaders.Add("Authorization", $"Token {_settings.ApiKey}");
                    client.DefaultRequestHeaders.Add("X-Secret", $"{_settings.SecretKey}");

                    using var response = await client.PostAsync($"{_settings.DadataAddress}", content);
                    result = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    var content = new StringContent($"[\"{message}\" ]", Encoding.UTF8, $"{overrideSettings.ContentType}");
                    client.DefaultRequestHeaders.Add("Authorization", $"Token {overrideSettings.ApiKey}");
                    client.DefaultRequestHeaders.Add("X-Secret", $"{overrideSettings.SecretKey}");

                    using var response = await client.PostAsync($"{overrideSettings.DadataAddress}", content);
                    result = await response.Content.ReadAsStringAsync();
                }

                return result;
            }
        }
    }
}
