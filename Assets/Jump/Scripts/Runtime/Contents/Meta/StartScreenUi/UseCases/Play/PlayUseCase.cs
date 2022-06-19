using Juce.Core.Disposables;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.ViewStack.Services;
using Template.Contents.Meta.StartScreenUi.Interactor;
using Template.Contexts.Stage;

namespace Template.Contents.Meta.StartScreenUi.UseCases.PlayAgain
{
    public sealed class PlayUseCase : IPlayUseCase
    {
        private readonly IUiViewStackService viewStackService;

        public PlayUseCase(
            IUiViewStackService viewStackService
            )
        {
            this.viewStackService = viewStackService;
        }

        public void Execute()
        {
            ITaskDisposable<IStageContextInteractor> stageContext = ServiceLocator.Get<ITaskDisposable<IStageContextInteractor>>();

            viewStackService.SetNotInteractableNow<IStartScreenUiInteractor>();

            viewStackService.New()
                .Hide<IStartScreenUiInteractor>(instantly: false)
                .Callback(stageContext.Value.Start)
                .Execute();
        }
    }
}