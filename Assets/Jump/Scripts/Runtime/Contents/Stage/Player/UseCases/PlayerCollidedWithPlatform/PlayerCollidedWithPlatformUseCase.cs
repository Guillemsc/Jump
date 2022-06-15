using Template.Contents.Stage.Physics.Colliders;
using Template.Contents.Stage.Platform.UseCases.DespawnOldestPlatform;
using Template.Contents.Stage.Platform.UseCases.IsPlatformIndexFromLastPlatformSpawned;
using Template.Contents.Stage.Platform.UseCases.TrySpawnNextPlatform;
using Template.Contents.Stage.Platform.Views;
using Template.Contents.Stage.Player.UseCases.SwitchPlayerDirection;
using Template.Contents.Stage.Points.Data;

namespace Template.Contents.Stage.Player.UseCases.PlayerCollidedWithPlatform
{
    public class PlayerCollidedWithPlatformUseCase : IPlayerCollidedWithPlatformUseCase
    {
        private readonly PointsData pointsData;
        private readonly ITrySpawnNextPlatformUseCase trySpawnNextPlatformUseCase;
        private readonly IDespawnOldestPlatformUseCase despawnOldestPlatformUseCase;
        private readonly IIsPlatformIndexFromLastPlatformSpawnedUseCase isPlatformIndexFromLastPlatformSpawnedUseCase;
        private readonly ISwitchPlayerDirectionUseCase switchPlayerDirectionUseCase;

        public PlayerCollidedWithPlatformUseCase(
            PointsData pointsData,
            ITrySpawnNextPlatformUseCase trySpawnNextPlatformUseCase,
            IDespawnOldestPlatformUseCase despawnOldestPlatformUseCase,
            IIsPlatformIndexFromLastPlatformSpawnedUseCase isPlatformIndexFromLastPlatformSpawnedUseCase,
            ISwitchPlayerDirectionUseCase switchPlayerDirectionUseCase
            )
        {
            this.pointsData = pointsData;
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

            if(isInitialPlatform)
            {
                return;
            }

            pointsData.Points.Value += 1;
        }
    }
}
