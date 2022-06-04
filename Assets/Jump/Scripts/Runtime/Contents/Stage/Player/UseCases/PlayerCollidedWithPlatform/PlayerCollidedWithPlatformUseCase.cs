using Template.Contents.Stage.Platform.UseCases.DespawnOldestPlatform;
using Template.Contents.Stage.Platform.UseCases.IsPlatformIndexFromLastPlatformSpawned;
using Template.Contents.Stage.Platform.UseCases.TrySpawnNextPlatform;
using Template.Contents.Stage.Platform.Views;
using Template.Contents.Stage.Player.UseCases.SwitchPlayerDirection;

namespace Template.Contents.Stage.Player.UseCases.PlayerCollidedWithPlatform
{
    public class PlayerCollidedWithPlatformUseCase : IPlayerCollidedWithPlatformUseCase
    {
        private readonly ITrySpawnNextPlatformUseCase trySpawnNextPlatformUseCase;
        private readonly IDespawnOldestPlatformUseCase despawnOldestPlatformUseCase;
        private readonly IIsPlatformIndexFromLastPlatformSpawnedUseCase isPlatformIndexFromLastPlatformSpawnedUseCase;
        private readonly ISwitchPlayerDirectionUseCase switchPlayerDirectionUseCase;

        public PlayerCollidedWithPlatformUseCase(
            ITrySpawnNextPlatformUseCase trySpawnNextPlatformUseCase,
            IDespawnOldestPlatformUseCase despawnOldestPlatformUseCase,
            IIsPlatformIndexFromLastPlatformSpawnedUseCase isPlatformIndexFromLastPlatformSpawnedUseCase,
            ISwitchPlayerDirectionUseCase switchPlayerDirectionUseCase
            )
        {
            this.trySpawnNextPlatformUseCase = trySpawnNextPlatformUseCase;
            this.despawnOldestPlatformUseCase = despawnOldestPlatformUseCase;
            this.isPlatformIndexFromLastPlatformSpawnedUseCase = isPlatformIndexFromLastPlatformSpawnedUseCase;
            this.switchPlayerDirectionUseCase = switchPlayerDirectionUseCase;
        }

        public void Execute(PlatformView platformView)
        {
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
        }
    }
}
