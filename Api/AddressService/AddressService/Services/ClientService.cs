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

        public async Task<string> SendPostRequest(string message)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                var content = new StringContent($"[\"{message}\" ]", Encoding.UTF8, $"{_settings.ContentType}");
                client.DefaultRequestHeaders.Add("Authorization", $"Token {_settings.ApiKey}");
                client.DefaultRequestHeaders.Add("X-Secret", $"{_settings.SecretKey}");


                using var response = await client.PostAsync($"{_settings.DadataAddress}", content);
                var result = await response.Content.ReadAsStringAsync();

                return result;
            }
        }
    }
}
