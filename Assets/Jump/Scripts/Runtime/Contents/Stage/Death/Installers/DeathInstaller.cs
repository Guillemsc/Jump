using Juce.Core.Di.Builder;
using Juce.Core.Disposables;
using Juce.Core.Repositories;
using JuceUnity.Core.Di.Extensions;
using Template.Contents.Services.Configuration.Service;
using Template.Contents.Stage.Death.UseCases.UseCases;
using Template.Contents.Stage.Platform.Views;
using Template.Contexts.Stage;

namespace Template.Contents.Stage.Death.Installers
{
    public static class DeathInstaller
    {
        public static void InstallDeath(this IDiContainerBuilder container)
        {
            container.Bind<IMoveDeathColliderToLastPlatformUseCase>()
                .FromFunction(c => new MoveDeathColliderToLastPlatformUseCase(
                    c.Resolve<StageContextInstance>().DeathCollider,
                    c.Resolve<IConfigurationService>().GameConfiguration.DeathColliderOffset,
                    c.Resolve<IRepository<IDisposable<PlatformView>>>()
                    ))
                .LinkToTickablesService(o => o.Execute)
                .NonLazy();
        }
    }
}
