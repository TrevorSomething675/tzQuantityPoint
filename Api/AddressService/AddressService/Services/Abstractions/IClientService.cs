using AddressService.Settings.SettingsModels;

namespace AddressService.Services.Abstractions
{
    public interface IClientService
    {
        public Task<string> SendPostRequest(string message, MainSettings overrideSettings = null);
    }
}
