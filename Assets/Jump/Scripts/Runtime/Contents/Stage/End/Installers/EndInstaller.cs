using Juce.Core.Di.Builder;
using Juce.CoreUnity.ViewStack.Services;
using Template.Contents.Stage.Camera.UseCases.StopFollowingPlayer;
using Template.Contents.Stage.End.UseCases.EndGame;

namespace Template.Contents.Stage.End.Installers
{
    public static class EndInstaller
    {
        public static void InstallEnd(this IDiContainerBuilder container)
        {
            container.Bind<IEndGameUseCase>()
                .FromFunction(c => new EndGameUseCase(
                    c.Resolve<IUiViewStackService>(),
                    c.Resolve<IStopFollowingPlayerUseCase>()
                    ));
        }
    }
}
