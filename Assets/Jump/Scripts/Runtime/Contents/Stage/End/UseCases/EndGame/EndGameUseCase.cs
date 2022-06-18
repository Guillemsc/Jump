using Juce.CoreUnity.ViewStack.Services;
using Template.Contents.Stage.Camera.UseCases.StopFollowingPlayer;
using Template.Contents.Stage.GameUi.Interactor;
using Template.Contents.Stage.PostGameUi.Interactor;

namespace Template.Contents.Stage.End.UseCases.EndGame
{
    public class EndGameUseCase : IEndGameUseCase
    {
        private readonly IUiViewStackService viewStackService;
        private readonly IStopFollowingPlayerUseCase stopFollowingPlayerUseCase;

        public EndGameUseCase(
            IUiViewStackService viewStackService,
            IStopFollowingPlayerUseCase stopFollowingPlayerUseCase
            )
        {
            this.viewStackService = viewStackService;
            this.stopFollowingPlayerUseCase = stopFollowingPlayerUseCase;
        }

        public void Execute()
        {
            stopFollowingPlayerUseCase.Execute();

            viewStackService.New()
                .Hide<IGameUiInteractor>(instantly: false)
                .Show<IPostGameUiInteractor>(instantly: false)
                .Execute();
        }
    }
}
