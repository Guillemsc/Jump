using Template.Contents.Stage.Platform.Views;

namespace Template.Contents.Stage.Platform.UseCases.TryGetClosetPlatformToPlayer
{
    public interface ITryGetClosetPlatformToPlayerUseCase
    {
        bool Execute(out PlatformView platformView);
    }
}
