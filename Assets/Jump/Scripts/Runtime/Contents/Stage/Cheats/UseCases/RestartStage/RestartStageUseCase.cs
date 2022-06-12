using Juce.Core.Disposables;
using Juce.Core.Extensions;
using Juce.CoreUnity.Loading.Services;
using Juce.CoreUnity.Service;
using System.Threading.Tasks;
using Template.Contexts.Stage;
using Template.Shared.UseCases;

namespace Template.Contents.Stage.Cheats.UseCases.RestartStage
{
    public class RestartStageUseCase : IRestartStageUseCase
    {
        private readonly ILoadingService loadingService;

        public RestartStageUseCase(
            ILoadingService loadingService
            )
        {
            this.loadingService = loadingService;
        }

        public void Execute() 
        {
            if(loadingService.IsLoading)
            {
                return;
            }

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
