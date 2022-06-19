using Template.Contents.Stage.Platform.Views;

namespace Template.Contents.Stage.Platform.UseCases.ActivatePlatform
{
    public interface IActivatePlatformUseCase
    {
        void Execute(PlatformView platformView);
    }
}
