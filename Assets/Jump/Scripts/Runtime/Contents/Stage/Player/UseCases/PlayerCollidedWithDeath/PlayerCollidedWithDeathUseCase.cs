using Template.Contents.Stage.End.UseCases.EndGame;
using Template.Contents.Stage.Physics.Colliders;

namespace Template.Contents.Stage.Player.UseCases.PlayerCollidedWithDeath
{
    public class PlayerCollidedWithDeathUseCase : IPlayerCollidedWithDeathUseCase
    {
        private readonly IEndGameUseCase endGameUseCase;

        public PlayerCollidedWithDeathUseCase(
            IEndGameUseCase endGameUseCase
            )
        {
            this.endGameUseCase = endGameUseCase;
        }

        public void Execute(DeathCollider deathCollider)
        {
            endGameUseCase.Execute();

            //if (loadingService.IsLoading)
            //{
            //    return;
            //}

            //loadingService.Enqueue(
            //    ReloadStageUseCase.Execute
            //    );

            //loadingService.Enqueue(() =>
            //{
            //    ITaskDisposable<IStageContextInteractor> stageContext = ServiceLocator.Get<ITaskDisposable<IStageContextInteractor>>();

            //    stageContext.Value.Start();
            //});
        }
    }
}
