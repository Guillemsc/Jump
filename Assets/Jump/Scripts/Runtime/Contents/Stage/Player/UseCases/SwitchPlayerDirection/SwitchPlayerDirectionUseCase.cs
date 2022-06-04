using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Template.Contents.Stage.Player.Views;

namespace Template.Contents.Stage.Player.UseCases.SwitchPlayerDirection
{
    public class SwitchPlayerDirectionUseCase : ISwitchPlayerDirectionUseCase
    {
        private readonly IReadOnlySingleRepository<IDisposable<PlayerView>> playerRepository;

        public SwitchPlayerDirectionUseCase(
            IReadOnlySingleRepository<IDisposable<PlayerView>> playerRepository
            )
        {
            this.playerRepository = playerRepository;
        }

        public void Execute()
        {
            bool playerFound = playerRepository.TryGet(out IDisposable<PlayerView> playerView);

            if (!playerFound)
            {
                return;
            }

            playerView.Value.PlayerViewController.ToggleDirection();
        }
    }
}
