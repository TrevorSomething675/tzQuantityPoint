namespace AddressService.Services.Abstractions
{
    public interface IClientService
    {
        public Task<string> SendPostRequest(string message)
    }
}
