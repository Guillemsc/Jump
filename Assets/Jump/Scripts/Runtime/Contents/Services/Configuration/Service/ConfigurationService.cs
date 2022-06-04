using Template.Contents.Shared.Configuration;

namespace Template.Contents.Services.Configuration.Service
{
    public class ConfigurationService : IConfigurationService
    {
        public GameConfiguration GameConfiguration { get; }

        public ConfigurationService(
            GameConfiguration gameConfiguration
            )
        {
            GameConfiguration = gameConfiguration;
        }
    }
}