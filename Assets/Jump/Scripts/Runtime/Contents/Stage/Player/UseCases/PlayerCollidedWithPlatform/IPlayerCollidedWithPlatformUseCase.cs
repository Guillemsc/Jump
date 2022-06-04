using Template.Contents.Stage.Platform.Views;

namespace Template.Contents.Stage.Player.UseCases.PlayerCollidedWithPlatform
{
    public interface IPlayerCollidedWithPlatformUseCase 
    {
        void Execute(PlatformView platformView);
    }
}
