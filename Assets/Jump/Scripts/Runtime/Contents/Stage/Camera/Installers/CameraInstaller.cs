using Juce.Core.Di.Builder;
using Juce.Core.Disposables;
using Juce.Core.Repositories;
using JuceUnity.Core.Di.Extensions;
using Template.Contents.Stage.Camera.UseCases.SetupCamera;
using Template.Contents.Stage.Camera.UseCases.StopFollowingPlayer;
using Template.Contents.Stage.Camera.UseCases.UpdateFollowCameraParent;
using Template.Contents.Stage.Player.Views;
using Template.Contexts.Stage;

namespace Template.Contents.Stage.Camera.Installers
{
    public static class CameraInstaller
    {
        public static void InstallCamera(this IDiContainerBuilder container)
        {
            container.Bind<ISetupCameraUseCase>()
                .FromFunction(c => new SetupCameraUseCase(
                    c.Resolve<StageContextInstance>().VirtualCamera,
                    c.Resolve<ISingleRepository<IDisposable<PlayerView>>>(),
                    c.Resolve<IUpdateFollowCameraParentUseCase>()
                    ));

            container.Bind<IStopFollowingPlayerUseCase>()
                .FromFunction(c => new StopFollowingPlayerUseCase(
                     c.Resolve<StageContextInstance>().VirtualCamera
                    ));

            container.Bind<IUpdateFollowCameraParentUseCase>()
                .FromFunction(c => new UpdateFollowCameraParentUseCase(
                     c.Resolve<StageContextInstance>().VirtualCamera,
                      c.Resolve<StageContextInstance>().FollowCameraParent
                    ))
                .LinkToTickablesService(o => o.Execute)
                .NonLazy();
        }
    }
}
