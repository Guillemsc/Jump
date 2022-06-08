using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Template.Contents.Stage.Physics.Colliders;
using Template.Contents.Stage.Platform.UseCases.DespawnOldestPlatform;
using Template.Contents.Stage.Platform.UseCases.IsPlatformIndexFromLastPlatformSpawned;
using Template.Contents.Stage.Platform.UseCases.TrySpawnNextPlatform;
using Template.Contents.Stage.Platform.Views;
using Template.Contents.Stage.Player.UseCases.SwitchPlayerDirection;
using Template.Contents.Stage.Player.Views;

namespace Template.Contents.Stage.Player.UseCases.PlayerCollidedWithPlatform
{
    public class PlayerCollidedWithPlatformUseCase : IPlayerCollidedWithPlatformUseCase
    {
        private readonly IReadOnlySingleRepository<IDisposable<PlayerView>> playerRepository;
        private readonly ITrySpawnNextPlatformUseCase trySpawnNextPlatformUseCase;
        private readonly IDespawnOldestPlatformUseCase despawnOldestPlatformUseCase;
        private readonly IIsPlatformIndexFromLastPlatformSpawnedUseCase isPlatformIndexFromLastPlatformSpawnedUseCase;
        private readonly ISwitchPlayerDirectionUseCase switchPlayerDirectionUseCase;

        public PlayerCollidedWithPlatformUseCase(
            IReadOnlySingleRepository<IDisposable<PlayerView>> playerRepository,
            ITrySpawnNextPlatformUseCase trySpawnNextPlatformUseCase,
            IDespawnOldestPlatformUseCase despawnOldestPlatformUseCase,
            IIsPlatformIndexFromLastPlatformSpawnedUseCase isPlatformIndexFromLastPlatformSpawnedUseCase,
            ISwitchPlayerDirectionUseCase switchPlayerDirectionUseCase
            )
        {
            this.playerRepository = playerRepository;
            this.trySpawnNextPlatformUseCase = trySpawnNextPlatformUseCase;
            this.despawnOldestPlatformUseCase = despawnOldestPlatformUseCase;
            this.isPlatformIndexFromLastPlatformSpawnedUseCase = isPlatformIndexFromLastPlatformSpawnedUseCase;
            this.switchPlayerDirectionUseCase = switchPlayerDirectionUseCase;
        }

        public void Execute(PlatformCollider platformCollider)
        {
            PlatformView platformView = platformCollider.GetComponentInParent<PlatformView>();

            bool isLastSpawned = isPlatformIndexFromLastPlatformSpawnedUseCase.Execute(platformView.PlatformIndex);

            if(!isLastSpawned)
            {
                return;
            }

            bool isInitialPlatform = platformView.PlatformIndex == 0;

            trySpawnNextPlatformUseCase.Execute();

            if (!isInitialPlatform)
            {
                despawnOldestPlatformUseCase.Execute();
            }

            switchPlayerDirectionUseCase.Execute();

            bool playerFound = playerRepository.TryGet(out IDisposable<PlayerView> playerView);

            if (!playerFound)
            {
                return;
            }

            playerView.Value.PlayerViewController.SetAsGrounded();
        }
    }
}
