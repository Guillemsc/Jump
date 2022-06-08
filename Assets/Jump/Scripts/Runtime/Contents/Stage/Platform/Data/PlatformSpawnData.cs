using Juce.Core.Direction;

namespace Template.Contents.Stage.Platform.Data
{
    public sealed class PlatformSpawnData
    {
        public int SpawnedPlatformsCount { get; set; }
        public float HighestSpawnedPlatform { get; set; }
        public HorizontalDirection LastSpawnedPlatformSide { get; set; }
    }
}
