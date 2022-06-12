using Juce.Core.Directions;
using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Template.Contents.Stage.Player.Views;

namespace Template.Contents.Stage.Player.UseCases.SetInitialPlayerDirection
{
    public class SetInitialPlayerDirectionUseCase : ISetInitialPlayerDirectionUseCase
    {
        private readonly HorizontalDirection initialPlayerDirection;
        private readonly IReadOnlySingleRepository<IDisposable<PlayerView>> playerRepository;

        public SetInitialPlayerDirectionUseCase(
            HorizontalDirection initialPlayerDirection,
            IReadOnlySingleRepository<IDisposable<PlayerView>> playerRepository
            )
        {
            this.initialPlayerDirection = initialPlayerDirection;
            this.playerRepository = playerRepository;
        }

        public void Execute()
        {
            bool playerFound = playerRepository.TryGet(out IDisposable<PlayerView> playerView);

            if (!playerFound)
            {
                return;
            }

            playerView.Value.PlayerViewController.SetDirection(initialPlayerDirection);
        }
    }
}
