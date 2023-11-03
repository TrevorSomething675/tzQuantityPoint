namespace AddressService.Settings.SettingsModels
{
    public class SwaggerSettings
    {
        public bool Enabled { get; private set; }

        public SwaggerSettings()
        {
            Enabled = false;
        }
    }
}
