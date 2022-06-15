using Template.Contents.Stage.General.Installers;
using Juce.Core.Di.Builder;
using Juce.CoreUnity.Contexts;
using Template.Contents.Stage.General.UseCases.LoadStage;
using Template.Contents.Stage.General.UseCases.StartStage;
using Template.Contents.Stage.Cheats.Installers;
using Template.Contents.Stage.Player.Installers;
using Template.Contents.Stage.Physics.Installers;
using Template.Contents.Stage.Camera.Installers;
using Template.Contents.Stage.Platform.Installers;
using Template.Contents.Stage.Death.Installers;

namespace Template.Contexts.Stage
{
    public sealed class StageContextInstaller : IContextInstaller<StageContextInstance>
    {
        public void Install(IDiContainerBuilder container, StageContextInstance context)
        {
            container.Bind<StageContextInstance>().FromInstance(context);

            container.InstallServices();
            container.InstallGeneral();

            container.InstallCheats();

            container.InstallPhysics();
            container.InstallCamera();
            container.InstallPlayer();
            container.InstallPlatform();
            container.InstallDeath();

            container.Bind(context.StageUiInstaller);

            container.Bind<IStageContextInteractor>().FromFunction(c => new StageContextInteractor(
                c.Resolve<ILoadStageUseCase>(),
                c.Resolve<IStartStageUseCase>()
                ));
        }
    }
}
