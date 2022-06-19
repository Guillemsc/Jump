using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Template.Contents.Stage.Player.Views;

namespace Template.Contents.Stage.Player.UseCases.SetPlayerMovementEnabled
{
    public class SetPlayerMovementEnabledUseCase : ISetPlayerMovementEnabledUseCase
    {
        private readonly IReadOnlySingleRepository<IDisposable<PlayerView>> playerRepository;

        public SetPlayerMovementEnabledUseCase(
            IReadOnlySingleRepository<IDisposable<PlayerView>> playerRepository
            )
        {
            this.playerRepository = playerRepository;
        }



        public void Execute(bool enabled)
        {
            bool playerFound = playerRepository.TryGet(out IDisposable<PlayerView> playerView);

            if (!playerFound)
            {
                return;
            }

            playerView.Value.PlayerViewMovementController.Enabled = enabled;
        }
    }
}
