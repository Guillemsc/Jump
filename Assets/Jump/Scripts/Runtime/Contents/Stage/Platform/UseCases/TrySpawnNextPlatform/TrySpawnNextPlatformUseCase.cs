using Juce.Core.Direction;
using Juce.Core.Disposables;
using Juce.Core.Repositories;
using Template.Contents.Stage.Platform.Data;
using Template.Contents.Stage.Platform.UseCases.GetNextPlatformSpawnHeight;
using Template.Contents.Stage.Platform.UseCases.SpawnPlatform;
using Template.Contents.Stage.Player.Views;

namespace Template.Contents.Stage.Platform.UseCases.TrySpawnNextPlatform
{
    public class TrySpawnNextPlatformUseCase : ITrySpawnNextPlatformUseCase
    {
        private readonly HorizontalDirection startingPlatformSide;
        private readonly PlatformSpawnData platformSpawnData;
        private readonly IReadOnlySingleRepository<IDisposable<PlayerView>> playerRepository;
        private readonly IGetNextPlatformSpawnHeightUseCase getNextPlatformSpawnHeightUseCase;
        private readonly ISpawnPlatformUseCase spawnPlatformUseCase;

        public TrySpawnNextPlatformUseCase(
            HorizontalDirection startingPlatformSide,
            PlatformSpawnData platformSpawnData,
            IReadOnlySingleRepository<IDisposable<PlayerView>> playerRepository,
            IGetNextPlatformSpawnHeightUseCase getNextPlatformSpawnHeightUseCase,
            ISpawnPlatformUseCase spawnPlatformUseCase
            )
        {
            this.startingPlatformSide = startingPlatformSide;
            this.platformSpawnData = platformSpawnData;
            this.playerRepository = playerRepository;
            this.getNextPlatformSpawnHeightUseCase = getNextPlatformSpawnHeightUseCase;
            this.spawnPlatformUseCase = spawnPlatformUseCase;
        }

        public void Execute()
        {
            bool playerFound = playerRepository.TryGet(out IDisposable<PlayerView> playerView);

            if(!playerFound)
            {
                return;
            }

            int platformIndex = platformSpawnData.SpawnedPlatformsCount;

            bool firstTime = platformIndex == 0;

            HorizontalDirection side = startingPlatformSide;

            if (!firstTime)
            {
                switch (platformSpawnData.LastSpawnedPlatformSide)
                {
                    case HorizontalDirection.Left:
                        {
                            side = HorizontalDirection.Right;
                            break;
                        }

                    case HorizontalDirection.Right:
                        {
                            side = HorizontalDirection.Left;
                            break;
                        }
                }
            }

            platformSpawnData.LastSpawnedPlatformSide = side;
            ++platformSpawnData.SpawnedPlatformsCount;

            float height = 0;

            if(!firstTime)
            {
                height = getNextPlatformSpawnHeightUseCase.Execute();
            }

            spawnPlatformUseCase.Execute(platformIndex, side, height);
        }
    }
}
