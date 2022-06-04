using Template.Contents.Stage.Platform.Factories;

namespace Template.Contents.Stage.Platform.UseCases.GetNextPlatformSpawnHeight
{
    public class GetNextPlatformSpawnHeightUseCase : IGetNextPlatformSpawnHeightUseCase
    {
        private readonly PlatformSpawnData platformSpawnData;
        private readonly float minPlatformSpawnHeight;
        private readonly float maxPlatformSpawnHeight;


        public GetNextPlatformSpawnHeightUseCase(
            PlatformSpawnData platformSpawnData,
            float minPlatformSpawnHeight,
            float maxPlatformSpawnHeight
            )
        {
            this.platformSpawnData = platformSpawnData;
            this.minPlatformSpawnHeight = minPlatformSpawnHeight;
            this.maxPlatformSpawnHeight = maxPlatformSpawnHeight;
        }

        public float Execute()
        {
            float spawnHeight = UnityEngine.Random.Range(minPlatformSpawnHeight, maxPlatformSpawnHeight);

            float finalSpawnHeight = platformSpawnData.HighestSpawnedPlatform + spawnHeight;

            platformSpawnData.HighestSpawnedPlatform = finalSpawnHeight;

            return finalSpawnHeight;
        }
    }
}
