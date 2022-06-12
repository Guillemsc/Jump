using Juce.Core.Disposables;
using Juce.CoreUnity.Loading.Services;
using Juce.CoreUnity.Service;
using Template.Contents.Stage.Physics.Colliders;
using Template.Contexts.Stage;
using Template.Shared.UseCases;

namespace Template.Contents.Stage.Player.UseCases.PlayerCollidedWithDeath
{
    public class PlayerCollidedWithDeathUseCase : IPlayerCollidedWithDeathUseCase
    {
        private readonly ILoadingService loadingService;

        public PlayerCollidedWithDeathUseCase(
            ILoadingService loadingService
            )
        {
            this.loadingService = loadingService;
        }

        public void Execute(DeathCollider deathCollider)
        {
            if (loadingService.IsLoading)
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
