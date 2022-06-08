using Juce.Core.Di.Builder;
using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using Template.Contents.Services.Configuration.Service;
using Template.Contents.Stage.Platform.Data;
using Template.Contents.Stage.Platform.Factories;
using Template.Contents.Stage.Platform.UseCases.DespawnOldestPlatform;
using Template.Contents.Stage.Platform.UseCases.DespawnPlatform;
using Template.Contents.Stage.Platform.UseCases.GetNextPlatformSpawnHeight;
using Template.Contents.Stage.Platform.UseCases.IsPlatformIndexFromLastPlatformSpawned;
using Template.Contents.Stage.Platform.UseCases.SpawnPlatform;
using Template.Contents.Stage.Platform.UseCases.TryGetClosetPlatformToPlayer;
using Template.Contents.Stage.Platform.UseCases.TrySpawnNextPlatform;
using Template.Contents.Stage.Platform.Views;
using Template.Contents.Stage.Player.Views;
using Template.Contexts.Stage;

namespace Template.Contents.Stage.Platform.Installers
{
    public static class PlatformInstaller
    {
        public static void InstallPlatform(this IDiContainerBuilder container)
        {
            container.Bind<PlatformSpawnData>().FromNew();

            container.Bind<IFactory<PlatformViewFactoryDefinition, IDisposable<PlatformView>>>()
                .FromFunction(c => new PlatformViewFactory(
                    c.Resolve<IConfigurationService>().GameConfiguration.PlatformViewPrefab,
                    c.Resolve<StageContextInstance>().PlatformViewsParent
                    ));

            container.Bind<IRepository<IDisposable<PlatformView>>>()
                .FromInstance(new SimpleRepository<IDisposable<PlatformView>>());

            container.Bind<ISpawnPlatformUseCase>()
                .FromFunction(c => new SpawnPlatformUseCase(
                    c.Resolve<IFactory<PlatformViewFactoryDefinition, IDisposable<PlatformView>>>(),
                    c.Resolve<IRepository<IDisposable<PlatformView>>>(),
                    c.Resolve<StageContextInstance>().PlatformViewsLeftSpawnPosition,
                    c.Resolve<StageContextInstance>().PlatformViewsRightSpawnPosition
                    ));

            container.Bind<IDespawnPlatformUseCase>()
                .FromFunction(c => new DespawnPlatformUseCase(
                    c.Resolve<IRepository<IDisposable<PlatformView>>>()
                    ));

            container.Bind<IGetNextPlatformSpawnHeightUseCase>()
                .FromFunction(c => new GetNextPlatformSpawnHeightUseCase(
                    c.Resolve<PlatformSpawnData>(),
                    c.Resolve<IConfigurationService>().GameConfiguration.MinPlatformSpawnHeight,
                    c.Resolve<IConfigurationService>().GameConfiguration.MaxPlatformSpawnHeight
                    ));

            container.Bind<ITrySpawnNextPlatformUseCase>()
                .FromFunction(c => new TrySpawnNextPlatformUseCase(
                    c.Resolve<IConfigurationService>().GameConfiguration.StartingPlatformSide,
                    c.Resolve<PlatformSpawnData>(),
                    c.Resolve<ISingleRepository<IDisposable<PlayerView>>>(),
                    c.Resolve<IGetNextPlatformSpawnHeightUseCase>(),
                    c.Resolve<ISpawnPlatformUseCase>()
                    ));

            container.Bind<IDespawnOldestPlatformUseCase>()
                .FromFunction(c => new DespawnOldestPlatformUseCase(
                    c.Resolve<IRepository<IDisposable<PlatformView>>>(),
                    c.Resolve<IDespawnPlatformUseCase>()
                    ));

            container.Bind<ITryGetClosetPlatformToPlayerUseCase>()
                .FromFunction(c => new TryGetClosetPlatformToPlayerUseCase(
                    c.Resolve<ISingleRepository<IDisposable<PlayerView>>>(),
                    c.Resolve<IRepository<IDisposable<PlatformView>>>()
                    ));

            container.Bind<IIsPlatformIndexFromLastPlatformSpawnedUseCase>()
                .FromFunction(c => new IsPlatformIndexFromLastPlatformSpawnedUseCase(
                    c.Resolve<PlatformSpawnData>()
                    ));
        }
    }
}
