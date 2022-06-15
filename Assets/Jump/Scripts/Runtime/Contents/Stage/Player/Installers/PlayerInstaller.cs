using Juce.Core.Di.Builder;
using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using Juce.CoreUnity.Loading.Services;
using Template.Contents.Services.Configuration.Service;
using Template.Contents.Stage.Platform.UseCases.DespawnOldestPlatform;
using Template.Contents.Stage.Platform.UseCases.IsPlatformIndexFromLastPlatformSpawned;
using Template.Contents.Stage.Platform.UseCases.TrySpawnNextPlatform;
using Template.Contents.Stage.Player.Factories;
using Template.Contents.Stage.Player.UseCases.PlayerCollided;
using Template.Contents.Stage.Player.UseCases.PlayerCollidedWithDeath;
using Template.Contents.Stage.Player.UseCases.PlayerCollidedWithPlatform;
using Template.Contents.Stage.Player.UseCases.SetInitialPlayerDirection;
using Template.Contents.Stage.Player.UseCases.SpawnPlayer;
using Template.Contents.Stage.Player.UseCases.SwitchPlayerDirection;
using Template.Contents.Stage.Player.Views;
using Template.Contents.Stage.Points.Data;
using Template.Contexts.Stage;

namespace Template.Contents.Stage.Player.Installers
{
    public static class PlayerInstaller
    {
        public static void InstallPlayer(this IDiContainerBuilder container)
        {
            container.Bind<IFactory<PlayerViewFactoryDefinition, IDisposable<PlayerView>>>()
                .FromFunction(c => new PlayerViewFactory(
                    c.Resolve<IConfigurationService>().GameConfiguration.PlayerViewPrefab,
                    c.Resolve<StageContextInstance>().PlayerViewParent
                    ));

            container.Bind<ISingleRepository<IDisposable<PlayerView>>>()
                .FromInstance(new SimpleSingleRepository<IDisposable<PlayerView>>());

            container.Bind<ISpawnPlayerUseCase>()
                .FromFunction(c => new SpawnPlayerUseCase(
                    c.Resolve<IFactory<PlayerViewFactoryDefinition, IDisposable<PlayerView>>>(),
                    c.Resolve<ISingleRepository<IDisposable<PlayerView>>>(),
                    c.Resolve<StageContextInstance>().PlayerViewSpawnPosition,
                    c.Resolve<IPlayerCollidedUseCase>()
                    ));

            container.Bind<IPlayerCollidedUseCase>()
                .FromFunction(c => new PlayerCollidedUseCase(
                    c.Resolve<IPlayerCollidedWithPlatformUseCase>(),
                    c.Resolve<IPlayerCollidedWithDeathUseCase>()
                    ));

            container.Bind<IPlayerCollidedWithPlatformUseCase>()
                .FromFunction(c => new PlayerCollidedWithPlatformUseCase(
                    c.Resolve<PointsData>(),
                    c.Resolve<ITrySpawnNextPlatformUseCase>(),
                    c.Resolve<IDespawnOldestPlatformUseCase>(),
                    c.Resolve<IIsPlatformIndexFromLastPlatformSpawnedUseCase>(),
                    c.Resolve<ISwitchPlayerDirectionUseCase>()
                    ));

            container.Bind<IPlayerCollidedWithDeathUseCase>()
                .FromFunction(c => new PlayerCollidedWithDeathUseCase(
                    c.Resolve<ILoadingService>()
                    ));

            container.Bind<ISetInitialPlayerDirectionUseCase>()
                .FromFunction(c => new SetInitialPlayerDirectionUseCase(
                    c.Resolve<IConfigurationService>().GameConfiguration.InitialPlayerDirection,
                    c.Resolve<ISingleRepository<IDisposable<PlayerView>>>()
                    ));

            container.Bind<ISwitchPlayerDirectionUseCase>()
                .FromFunction(c => new SwitchPlayerDirectionUseCase(
                    c.Resolve<ISingleRepository<IDisposable<PlayerView>>>()
                    ));
        }
    }
}
