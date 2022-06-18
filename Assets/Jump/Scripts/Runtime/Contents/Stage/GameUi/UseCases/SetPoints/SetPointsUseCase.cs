using Juce.TweenComponent;
using Template.Contents.Stage.GameUi.Bindings;

namespace Template.Contents.Stage.GameUi.UseCases.SetPoints
{
    public sealed class SetPointsUseCase : ISetPointsUseCase
    {
        private readonly TweenPlayer setPointsTween;

        public SetPointsUseCase(
            TweenPlayer setPointsTween
            )
        {
            this.setPointsTween = setPointsTween;
        }

        public void Execute(int points)
        {
            SetGamePointsBinding setPointsBinding = new SetGamePointsBinding
            {
                PointsString = points.ToString()
            };

            setPointsTween.Play(setPointsBinding);
        }
    }
}
