using Juce.Core.Di.Builder;
using Juce.CoreUnity.Loading.Services;
using Juce.CoreUnity.Tickables;
using Juce.CoreUnity.ViewStack.Services;
using JuceUnity.Core.DI.Extensions;
using Template.Contents.Services.Configuration.Service;
using Template.Contents.Services.Events.Service;

namespace Template.Contents.Stage.General.Installers
{
    public static class ServicesInstaller
    {
        public static void InstallServices(this IDiContainerBuilder container)
        {
            container.Bind<ILoadingService>().FromServicesLocator();
            container.Bind<ITickablesService>().FromServicesLocator();
            container.Bind<IUiViewStackService>().FromServicesLocator();
            container.Bind<IConfigurationService>().FromServicesLocator();
            container.Bind<IEventsService>().FromServicesLocator();
        }
    }
}
