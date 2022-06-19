using Juce.Core.Disposables;
using Juce.CoreUnity.Loading.Services;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.ViewStack.Services;
using Template.Contents.Stage.PostGameUi.Interactor;
using Template.Contexts.Stage;
using Template.Shared.UseCases;

namespace Template.Contents.Stage.PostGameUi.UseCases.PlayAgain
{
    public sealed class PlayAgainUseCase : IPlayAgainUseCase
    {
        private readonly IUiViewStackService viewStackService;
        private readonly ILoadingService loadingService;

        public PlayAgainUseCase(
            IUiViewStackService viewStackService,
            ILoadingService loadingService
            )
        {
            this.viewStackService = viewStackService;
            this.loadingService = loadingService;
        }

        public void Execute()
        {
            if (loadingService.IsLoading)
            {
                return;
            }

            viewStackService.SetNotInteractableNow<IPostGameUiInteractor>();

            loadingService.Enqueue(
                ReloadStageUseCase.Execute
                );

            loadingService.Enqueue(() =>
            {
                ITaskDisposable<IStageContextInteractor> stageContext = ServiceLocator.Get<ITaskDisposable<IStageContextInteractor>>();

                stageContext.Value.Start();
            });
        }
    }
}