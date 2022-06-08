using Juce.Core.Disposables;
using Juce.Core.Extensions;
using Juce.Core.Loading;
using Juce.CoreUnity.Service;
using System.Threading;
using System.Threading.Tasks;
using Template.Contents.Stage.Physics.Colliders;
using Template.Contexts.LoadingScreen;
using Template.Contexts.Shared.Factories;
using Template.Contexts.Stage;

namespace Template.Contents.Stage.Player.UseCases.PlayerCollidedWithDeath
{
    public class PlayerCollidedWithDeathUseCase : IPlayerCollidedWithDeathUseCase
    {
        public void Execute(DeathCollider deathCollider)
        {
            Execute().RunAsync();
        }

        private async Task Execute()
        {
            ITaskDisposable<ILoadingScreenContextInteractor> loadingScreenContext = ServiceLocator.Get<ITaskDisposable<ILoadingScreenContextInteractor>>();

            ITaskLoadingToken taskLoadingToken = await loadingScreenContext.Value.Show(CancellationToken.None);

            ITaskDisposable<IStageContextInteractor> stageContext = ServiceLocator.Get<ITaskDisposable<IStageContextInteractor>>();

            await stageContext.Dispose();

            stageContext = await ContextFactories.Stage.Create();

            stageContext.Value.Load();

            await taskLoadingToken.Complete();

            stageContext.Value.Start();
        }
    }
}
