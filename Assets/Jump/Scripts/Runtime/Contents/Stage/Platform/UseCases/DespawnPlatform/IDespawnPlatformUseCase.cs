using Juce.Core.Disposables;
using Template.Contents.Stage.Platform.Views;

namespace Template.Contents.Stage.Platform.UseCases.DespawnPlatform
{
    public interface IDespawnPlatformUseCase
    {
        void Execute(IDisposable<PlatformView> platform);
    }
}
