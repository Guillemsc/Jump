using Juce.TweenComponent;
using Template.Contents.Stage.PostGameUi.Bindings;

namespace Template.Contents.Stage.PostGameUi.UseCases.PlayPointsAnimation
{
    public class PlayPointsAnimationUseCase : IPlayPointsAnimationUseCase
    {
        private readonly TweenPlayer setPointsTween;

        public PlayPointsAnimationUseCase(
            TweenPlayer setPointsTween
            )
        {
            this.setPointsTween = setPointsTween;
        }

        public void Execute(int points)
        {
            SetPostGamePointsBinding setPointsBinding = new SetPostGamePointsBinding
            {
                PointsInt = points,
            };

            setPointsTween.Play(setPointsBinding);

            setPointsTween.Play();
        }
    }
}