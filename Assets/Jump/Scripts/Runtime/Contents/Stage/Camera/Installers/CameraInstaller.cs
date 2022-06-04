using Juce.Core.Di.Builder;
using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Template.Contents.Stage.Camera.UseCases.SetupCamera;
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
                    c.Resolve<ISingleRepository<IDisposable<PlayerView>>>()
                    ));
        }
    }
}
