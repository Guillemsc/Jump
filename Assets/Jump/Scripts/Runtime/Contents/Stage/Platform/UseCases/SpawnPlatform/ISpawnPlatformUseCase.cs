using Juce.Core.Directions;

namespace Template.Contents.Stage.Platform.UseCases.SpawnPlatform
{
    public interface ISpawnPlatformUseCase
    {
        void Execute(int platformIndex, HorizontalDirection side, float height);
    }
}
