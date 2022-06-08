using Template.Contents.Stage.Platform.Data;

namespace Template.Contents.Stage.Platform.UseCases.IsPlatformIndexFromLastPlatformSpawned
{
    public sealed class IsPlatformIndexFromLastPlatformSpawnedUseCase : IIsPlatformIndexFromLastPlatformSpawnedUseCase
    {
        private readonly PlatformSpawnData platformSpawnData;

        public IsPlatformIndexFromLastPlatformSpawnedUseCase(
            PlatformSpawnData platformSpawnData
            )
        {
            this.platformSpawnData = platformSpawnData;
        }

        public bool Execute(int platformIndex)
        {
            return platformIndex == platformSpawnData.SpawnedPlatformsCount - 1;
        }
    }
}
