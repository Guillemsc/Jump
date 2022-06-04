using Template.Contents.Shared.Configuration;

namespace Template.Contents.Services.Configuration.Service
{
    public interface IConfigurationService 
    {
        public GameConfiguration GameConfiguration { get; }
    }
}