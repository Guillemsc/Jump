using Juce.TweenComponent;
using Template.Contents.Stage.PostGameUi.Bindings;

namespace Template.Contents.Stage.PostGameUi.UseCases.PlayPointsAnimation
{
    public class PlayPointsAnimationUseCase : IPlayPointsAnimationUseCase
    {
        private readonly TweenPlayer setPointsTween;
        private readonly TweenPlayer highScoreTween;

        public PlayPointsAnimationUseCase(
            TweenPlayer setPointsTween,
            TweenPlayer highScoreTween
            )
        {
            this.setPointsTween = setPointsTween;
            this.highScoreTween = highScoreTween;
        }

        public void Execute(int points, bool highScore)
        {
            SetPostGamePointsBinding setPointsBinding = new SetPostGamePointsBinding
            {
                PointsInt = points,
            };

            setPointsTween.Play(setPointsBinding);

            if(highScore)
            {
                highScoreTween.Play();
            }
        }
    }
}