using Template.Contents.Stage.Platform.Views;

namespace Template.Contents.Stage.Platform.UseCases.ActivatePlatform
{
    public class ActivatePlatformUseCase : IActivatePlatformUseCase
    {
        public void Execute(PlatformView platformView)
        {
            platformView.ActivateTween.Play();
        }
    }
}
